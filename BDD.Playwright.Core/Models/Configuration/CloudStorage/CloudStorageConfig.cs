namespace BDD.Playwright.Core.Models.Configuration.CloudStorage
{
    /// <summary>
    /// Represents the cloud storage configuration settings.
    /// </summary>
    public class CloudStorageConfig
    {
        /// <summary>
        /// Gets or sets a value indicating whether cloud storage is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the cloud storage provider type (e.g., "Azure", "AWS", "Google").
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the Azure-specific storage configuration.
        /// </summary>
        public AzureStorageConfig AzureConfig { get; set; }

        /// <summary>
        /// Gets or sets the AWS-specific storage configuration.
        /// </summary>
        public AwsStorageConfig AwsConfig { get; set; }

        /// <summary>
        /// Gets or sets the Google-specific storage configuration.
        /// </summary>
        public GoogleStorageConfig GoogleConfig { get; set; }
    }
}
