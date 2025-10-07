namespace BDD.Playwright.Core.Models.Configuration
{
    using System;
    using BDD.Playwright.Core.Models.Configuration.FileSourceConfigurations;
    using Newtonsoft.Json;

    /// <summary>
    /// Configuration for address lists, supporting local file, cloud, or database sources.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This configuration allows specifying multiple address sources for use in test data scenarios.
    /// </para>
    /// </remarks>
    public class AddressListConfig
    {
        /// <summary>
        /// Gets or sets the name of the address list.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the source type for the address list ("LocalFile", "Cloud", or "Database").
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the local file configuration for the address list.
        /// </summary>
        public LocalFileConfig LocalFileConfig { get; set; }

        /// <summary>
        /// Gets or sets the cloud configuration for the address list.
        /// </summary>
        public AddressCloudConfig CloudConfig { get; set; }

        /// <summary>
        /// Gets or sets the database configuration for the address list.
        /// </summary>
        public AddressDatabaseConfig DatabaseConfig { get; set; }

        /// <summary>
        /// Gets the active configuration based on the source type.
        /// </summary>
        [JsonIgnore]
        public object ActiveConfig => GetActiveConfig();

        private object GetActiveConfig()
        {
            return Source?.ToLowerInvariant() switch
            {
                "localfile" => LocalFileConfig,
                "cloud" => CloudConfig,
                "database" => DatabaseConfig,
                _ => throw new InvalidOperationException($"Unknown storage type: {Source}")
            };
        }
    }
}
