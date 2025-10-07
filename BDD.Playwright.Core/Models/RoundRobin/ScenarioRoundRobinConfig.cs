// ScenarioRoundRobinConfig.cs
namespace BDD.Playwright.Core.Models.RoundRobin
{
    /// <summary>
    /// Represents round robin configuration state for a specific test scenario.
    /// Tracks the scenario name, last execution date, and the current address index in the address pool.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Used by round robin managers to persist and retrieve the last used address for each scenario,
    /// enabling fair distribution of test data across runs.
    /// </para>
    /// </remarks>
    public class ScenarioRoundRobinConfig
    {
        /// <summary>
        /// Gets or sets the scenario name.
        /// </summary>
        public string ScenarioName { get; set; }

        /// <summary>
        /// Gets or sets the date when the scenario was last executed (format: yyyy/MM/dd).
        /// </summary>
        public string LastRunDate { get; set; }

        /// <summary>
        /// Gets or sets the index of the current address assigned to the scenario.
        /// </summary>
        public int CurrentAddressIndex { get; set; }
    }
}