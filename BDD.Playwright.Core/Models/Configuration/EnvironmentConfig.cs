namespace BDD.Playwright.Core.Models.Configuration
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents environment-specific configuration for a product, including product suite endpoints and credentials.
    /// </summary>
    public class EnvironmentConfig
    {
        /// <summary>
        /// Gets or sets the product suite configurations for this environment, keyed by suite name.
        /// </summary>
        public Dictionary<string, ProductSuiteConfig> ProductSuites { get; set; }
    }
}
