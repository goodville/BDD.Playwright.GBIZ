namespace BDD.Playwright.Core.Models.Configuration
{
    using System;
    using BDD.Playwright.Core.Models.Configuration.FileSourceConfigurations;
    using Newtonsoft.Json;

    /// <summary>
    /// Configuration for round robin address selection.
    /// Supports enabling/disabling, and selecting between cloud or database sources.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This configuration determines how round robin state is persisted and retrieved for test scenarios.
    /// </para>
    /// </remarks>
    /// <example>
    /// <code language="json">
    /// {
    ///   "RoundRobinConfiguration": {
    ///     "Enabled": true,
    ///     "Source": "Cloud",
    ///     "CloudConfig": { "Container": "roundrobin-config" }
    ///   }
    /// }
    /// </code>
    /// </example>
    public class RoundRobinConfig
    {
        /// <summary>
        /// Gets or sets a value indicating whether the round-robin configuration is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the source type for the round-robin configuration.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the cloud configuration for round-robin address selection.
        /// </summary>
        public RoundRobinCloudConfig CloudConfig { get; set; }

        /// <summary>
        /// Gets or sets the database configuration for round-robin address selection.
        /// </summary>
        public RoundRobinDatabaseConfig DatabaseConfig { get; set; }

        /// <summary>
        /// Gets the active configuration based on the source type.
        /// </summary>
        [JsonIgnore]
        public object ActiveConfig => GetActiveConfig();

        private object GetActiveConfig()
        {
            return !Enabled
                ? null
                : Source?.ToLowerInvariant() switch
                {
                    "cloud" => CloudConfig,
                    "database" => DatabaseConfig,
                    _ => throw new InvalidOperationException($"Unknown source type: {Source}")
                };
        }
    }
}
