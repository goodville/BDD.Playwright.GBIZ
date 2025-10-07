namespace BDD.Playwright.Core.Factories
{
    using System.Threading.Tasks;
    using BDD.Playwright.Core.Interfaces;
    using BDD.Playwright.Core.Managers.RoundRobin;

    /// <summary>
    /// Factory for creating instances of <see cref="IRoundRobinManager"/> for cloud-based round robin management.
    /// Ensures the address pool is initialized before returning the manager instance.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this factory to abstract the instantiation and initialization of round robin managers, allowing test code to remain agnostic to the underlying implementation.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// IRoundRobinManager roundRobinManager = await RoundRobinFactory.CreateCloudRoundRobinAsync(
    ///     cloudStorageManager,
    ///     addressProvider,
    ///     "config-container"
    /// );
    /// Address address = await roundRobinManager.GetAddressAsync("MyScenario");
    /// // ... use address ...
    /// await roundRobinManager.SaveScenarioRoundRobinConfigAsync();
    /// </code>
    /// </example>
    public class RoundRobinFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="IRoundRobinManager"/> for cloud-based round robin management.
        /// The returned manager is fully initialized and ready for use.
        /// </summary>
        /// <param name="cloudStorageManager">The cloud storage manager used to persist round robin state.</param>
        /// <param name="addressProvider">The address provider used to load the address pool.</param>
        /// <param name="configContainer">The name of the cloud storage container or bucket with round robin config files.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains an initialized <see cref="IRoundRobinManager"/>.</returns>
        public static async Task<IRoundRobinManager> CreateCloudRoundRobinAsync(ICloudStorageManager cloudStorageManager, IAddressProvider addressProvider, string configContainer)
        {
            var roundRobinManager = new CloudRoundRobinManager(cloudStorageManager, addressProvider, configContainer);
            await roundRobinManager.InitializeAddressListAsync();
            return roundRobinManager;
        }
    }
}