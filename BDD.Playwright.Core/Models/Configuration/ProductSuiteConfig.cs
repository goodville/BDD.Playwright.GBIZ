namespace BDD.Playwright.Core.Models.Configuration
{
    /// <summary>
    /// Represents configuration for a product suite, including URLs and credentials for UI and API access.
    /// </summary>
    public class ProductSuiteConfig
    {
        /// <summary>
        /// Gets or sets the main URL for the product suite.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the username for UI access.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password for UI access.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the API endpoint URL.
        /// </summary>
        public string ApiEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the username for API access.
        /// </summary>
        public string ApiUsername { get; set; }

        /// <summary>
        /// Gets or sets the password for API access.
        /// </summary>
        public string ApiPassword { get; set; }
    }
}