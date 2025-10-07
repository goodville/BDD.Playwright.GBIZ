namespace BDD.Playwright.Core.Models.Configuration.FileSourceConfigurations
{
    /// <summary>
    /// Represents configuration settings for retrieving address data from a local file source.
    /// Used to specify the file path and the data key for extracting address data from a local file.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This configuration is typically used by address providers that load address lists from local JSON or other structured files.
    /// </para>
    /// </remarks>
    /// <example>
    /// <code language="json">
    /// {
    ///   "AddressLists": {
    ///     "MyLocalList": {
    ///       "Source": "LocalFile",
    ///       "LocalFileConfig": {
    ///         "FilePath": "addresses.json",
    ///         "DataKey": "addressList"
    ///       }
    ///     }
    ///   }
    /// }
    /// </code>
    /// </example>
    public class LocalFileConfig
    {
        /// <summary>
        /// Gets or sets the file path for the local file source.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the JSON data key to extract from the local file.
        /// </summary>
        public string DataKey { get; set; }
    }
}
