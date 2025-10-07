namespace BDD.Playwright.Core.Models.Configuration
{
    using BDD.Playwright.Core.Models.Configuration.CloudStorage;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the root configuration for the test automation project.
    /// Contains global settings, environment and product configurations, and integration endpoints.
    /// </summary>
    public class TestAutomationSettings
    {
        /// <summary>
        /// Gets or sets the username for authentication.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password for authentication.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Azure DevOps project name.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the Azure Key Vault name.
        /// </summary>
        public string KeyVaultName { get; set; }

        /// <summary>
        /// Gets or sets the Azure DevOps sprint name.
        /// </summary>
        public string SprintName { get; set; }

        /// <summary>
        /// Gets or sets the test environment name.
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// Gets or sets the headless test execution flag.
        /// </summary>
        public string Headless { get; set; }

        /// <summary>
        /// Gets or sets the browser type.
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// Gets or sets the execution type (e.g., local, grid, azure).
        /// </summary>
        public string ExecutionType { get; set; }

        /// <summary>
        /// Gets or sets the remote hub URL for distributed execution.
        /// </summary>
        public string RemoteHubURL { get; set; }

        /// <summary>
        /// Gets or sets the test category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the dashboard URL for reporting.
        /// </summary>
        public string DashboardURL { get; set; }

        /// <summary>
        /// Gets or sets the page-level screenshot setting.
        /// </summary>
        public string PageLevelScreenshot { get; set; }

        /// <summary>
        /// Gets or sets the QA database connection string.
        /// </summary>
        public string DBConnectionQA { get; set; }

        /// <summary>
        /// Gets or sets the release link (e.g., Azure DevOps release URL).
        /// </summary>
        public string ReleaseLink { get; set; }

        /// <summary>
        /// Gets or sets the test run ID.
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Gets or sets the test run ID (alternate property).
        /// </summary>
        public int RunId { get; set; } = 0;

        /// <summary>
        /// Gets or sets the authentication method.
        /// </summary>
        public string Authentication { get; set; }

        /// <summary>
        /// Gets or sets the retry count for failed operations.
        /// </summary>
        public string RetryCount { get; set; }

        /// <summary>
        /// Gets or sets the cloud storage configuration.
        /// </summary>
        public CloudStorageConfig CloudStorageConfig { get; set; }

        /// <summary>
        /// Gets or sets the global timeout (in seconds).
        /// </summary>
        public int GlobalTimeout { get; set; }

        /// <summary>
        /// Gets or sets the web element timeout (in seconds).
        /// </summary>
        public int WebElementTimeout { get; set; }

        /// <summary>
        /// Gets or sets the folder path for test data files.
        /// </summary>
        public string TestDataFolderPath { get; set; }

        /// <summary>
        /// Gets or sets the round robin configuration.
        /// </summary>
        public RoundRobinConfig RoundRobinConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the address lists configuration.
        /// </summary>
        public Dictionary<string, AddressListConfig> AddressLists { get; set; }

        /// <summary>
        /// Gets or sets the PDF comparison service URLs.
        /// </summary>
        public PDFCompareUrlsConfig PDFCompareUrls { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product configurations.
        /// </summary>
        public List<ProductConfig> Products { get; set; }
    }
}