namespace BDD.Playwright.Core.Models.Configuration.FileSourceConfigurations
{
    /// <summary>
    /// Represents configuration settings for retrieving address data from a cloud storage source.
    /// Used to specify the container or bucket and the file name where address data is stored in the cloud.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This configuration is typically used by address providers that load address lists from cloud storage services
    /// such as AWS S3, Azure Blob Storage, or Google Cloud Storage.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage in configuration:
    /// </para>
    /// <code language="json">
    /// {
    ///   "AddressLists": {
    ///     "MyCloudList": {
    ///       "Source": "Cloud",
    ///       "CloudConfig": {
    ///         "Container": "address-container",
    ///         "FileName": "addresses.json"
    ///       }
    ///     }
    ///   }
    /// }
    /// </code>
    /// </example>
    public class AddressCloudConfig
    {
        /// <summary>
        /// Gets or sets the cloud storage container or bucket name where the address file is stored.
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        /// Gets or sets the file name in the cloud storage that contains the address data.
        /// </summary>
        public string FileName { get; set; }
    }
}