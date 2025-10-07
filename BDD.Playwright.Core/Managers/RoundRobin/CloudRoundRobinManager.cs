namespace BDD.Playwright.Core.Managers.RoundRobin
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using BDD.Playwright.Core.Interfaces;
    using BDD.Playwright.Core.Models.RoundRobin;
    using Newtonsoft.Json;

    /// <summary>
    /// Manages round robin address selection and configuration for test scenarios using cloud storage as the backing store.
    /// Maintains a pool of addresses and tracks the last used address for each scenario, persisting state per scenario.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <b>Usage pattern:</b> Call <see cref="InitializeAddressListAsync"/> before using <see cref="GetAddressAsync"/> to ensure the address pool is loaded.
    /// After retrieving an address, call <see cref="SaveScenarioRoundRobinConfigAsync"/> to persist the updated round robin state.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// var roundRobinManager = new CloudRoundRobinManager(cloudStorageManager, addressProvider, "config-container");
    /// await roundRobinManager.InitializeAddressListAsync();
    /// Address address = await roundRobinManager.GetAddressAsync("MyScenario");
    /// // ... use address ...
    /// await roundRobinManager.SaveScenarioRoundRobinConfigAsync();
    /// </code>
    /// </example>
    internal class CloudRoundRobinManager : IRoundRobinManager
    {
        private static readonly SemaphoreSlim RoundRobinSemaphoreSlim = new(1, 1);
        private readonly string configContainer;
        private readonly ICloudStorageManager cloudStorageManager;
        private readonly IAddressProvider addressProvider;
        private IList<Address> addressPool = null;
        private ScenarioRoundRobinConfig scenarioRoundRobin = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudRoundRobinManager"/> class.
        /// </summary>
        /// <param name="cloudStorageManager">The cloud storage manager used to persist round robin state.</param>
        /// <param name="addressProvider">The address provider used to load the address pool.</param>
        /// <param name="configContainer">The name of the configuration container in cloud storage.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="cloudStorageManager"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="addressProvider"/> or <paramref name="configContainer"/> is null.</exception>
        public CloudRoundRobinManager(ICloudStorageManager cloudStorageManager, IAddressProvider addressProvider, string configContainer)
        {
            this.cloudStorageManager = cloudStorageManager ?? throw new ArgumentException(nameof(cloudStorageManager));
            this.addressProvider = addressProvider ?? throw new ArgumentNullException(nameof(addressProvider));
            this.configContainer = configContainer ?? throw new ArgumentNullException(nameof(configContainer));
        }

        /// <summary>
        /// Initializes the address list asynchronously from the address provider.
        /// Must be called before using <see cref="GetAddressAsync"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown if no addresses are found in the address pool.</exception>
        public async Task InitializeAddressListAsync()
        {
            if (addressPool == null)
            {
                addressPool = await addressProvider.LoadAddressesAsync();
                if (addressPool == null || addressPool.Count == 0)
                {
                    throw new InvalidOperationException("No addresses found in the address pool.");
                }
            }
        }

        /// <summary>
        /// Gets the address for the current scenario based on round robin logic.
        /// If the scenario is run on a new day, the address index is advanced.
        /// </summary>
        /// <param name="scenarioName">The scenario name used to identify the round robin state.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains the <see cref="Address"/> for the scenario.
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown if the address pool is not initialized or contains no addresses.</exception>
        public async Task<Address> GetAddressAsync(string scenarioName)
        {
            var fileName = string.Join("_", scenarioName.Split(Path.GetInvalidFileNameChars())).ToLower();
            var roundRobinConfigData = await cloudStorageManager.DownloadFileAsStringAsync(configContainer, fileName);

            scenarioRoundRobin = string.IsNullOrEmpty(roundRobinConfigData)
                ? new ScenarioRoundRobinConfig()
                {
                    ScenarioName = scenarioName,
                    LastRunDate = DateTime.Now.ToString("yyyy/MM/dd"),
                    CurrentAddressIndex = 0,
                }
                : JsonConvert.DeserializeObject<ScenarioRoundRobinConfig>(roundRobinConfigData);

            if (DateTime.Today > DateTime.Parse(scenarioRoundRobin.LastRunDate))
            {
                scenarioRoundRobin.LastRunDate = DateTime.Now.ToString("yyyy/MM/dd");
                scenarioRoundRobin.CurrentAddressIndex = (scenarioRoundRobin.CurrentAddressIndex + 1) % addressPool.Count;
            }

            return addressPool[scenarioRoundRobin.CurrentAddressIndex];
        }

        /// <summary>
        /// Saves the updated round robin configuration for the current scenario to cloud storage.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Uses a semaphore to ensure thread-safe updates to the round robin state in cloud storage.
        /// </remarks>
        public async Task SaveScenarioRoundRobinConfigAsync()
        {
            if (scenarioRoundRobin != null)
            {
                var fileName = string.Join("_", scenarioRoundRobin.ScenarioName.Split(Path.GetInvalidFileNameChars())).ToLower();
                await RoundRobinSemaphoreSlim.WaitAsync();
                try
                {
                    var roundRobinJson = JsonConvert.SerializeObject(scenarioRoundRobin, Formatting.Indented);
                    await cloudStorageManager.UploadFileAsync(configContainer, fileName, roundRobinJson);
                }
                finally
                {
                    RoundRobinSemaphoreSlim.Release();
                }
            }
        }
    }
}
