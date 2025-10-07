namespace BDD.Playwright.Core.Interfaces
{
    using System.Threading.Tasks;
    using BDD.Playwright.Core.Models.RoundRobin;

    /// <summary>
    /// Defines a contract for managing round robin address selection for test scenarios.
    /// Implementations may persist and retrieve round robin state from cloud storage or other sources.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Implementations such as <c>CloudRoundRobinManager</c> maintain a pool of addresses and track the last used address for each scenario.
    /// The round robin state is typically persisted per scenario and updated on each access.
    /// </para>
    /// <para>
    /// <b>Usage pattern:</b> Call <c>InitializeAddressListAsync</c> (if available) before using <c>GetAddressAsync</c> to ensure the address pool is loaded.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// IRoundRobinManager roundRobinManager = new CloudRoundRobinManager(cloudStorageManager, addressProvider, "config-container");
    /// await roundRobinManager.InitializeAddressListAsync();
    /// Address address = await roundRobinManager.GetAddressAsync("MyScenario");
    /// // ... use address ...
    /// await roundRobinManager.SaveScenarioRoundRobinConfigAsync();
    /// </code>
    /// </example>
    public interface IRoundRobinManager
    {
        /// <summary>
        /// Gets the address elements for the current address in the round robin configuration for the specified scenario.
        /// </summary>
        /// <param name="scenarioName">The scenario name used to identify the round robin state.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains the <see cref="Address"/> for the scenario.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown if the address pool is not initialized or contains no addresses.
        /// </exception>
        Task<Address> GetAddressAsync(string scenarioName);

        /// <summary>
        /// Saves the updated round robin configuration for the current scenario.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Implementations may persist the round robin state to cloud storage or another backing store.
        /// </remarks>
        Task SaveScenarioRoundRobinConfigAsync();
    }
}
