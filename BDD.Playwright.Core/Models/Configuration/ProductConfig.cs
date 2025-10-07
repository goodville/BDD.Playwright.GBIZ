namespace BDD.Playwright.Core.Models.Configuration
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents configuration for a product, including its name and environment-specific settings.
    /// </summary>
    public class ProductConfig
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the environment configurations for this product, keyed by environment name.
        /// </summary>
        public Dictionary<string, EnvironmentConfig> Environments { get; set; }
    }
}