namespace BDD.Playwright.Core.Factories
{
    using BDD.Playwright.Core.Interfaces;
    using BDD.Playwright.Core.Managers.AddressProviders;

    /// <summary>
    /// Factory for creating <see cref="IAddressProvider"/> instances for use in test data scenarios.
    /// Supports creation of address providers that load addresses from local files or cloud storage.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this factory to abstract the instantiation of address providers, allowing test code to remain agnostic to the underlying data source.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// // Create a local file address provider
    /// IAddressProvider localProvider = AddressProviderFactory.CreateLocalFileAddressProvider(fileReader, "addresses.json", "addressList");
    ///
    /// // Create a cloud address provider
    /// IAddressProvider cloudProvider = AddressProviderFactory.CreateCloudAddressProvider(cloudStorageManager, "address-container", "addresses.json");
    /// </code>
    /// </example>
    public class AddressProviderFactory
    {
        /// <summary>
        /// Creates an <see cref="IAddressProvider"/> that loads addresses from a local file.
        /// </summary>
        /// <param name="fileReader">The file reader used to access the local file (e.g., <c>JsonReader</c>).</param>
        /// <param name="filePath">The path to the local file containing address data.</param>
        /// <param name="dataKey">The key used to retrieve the address data from the file (e.g., a JSONPath expression).</param>
        /// <returns>An <see cref="IAddressProvider"/> for local file access.</returns>
        public static IAddressProvider CreateLocalFileAddressProvider(IFileReader fileReader, string filePath, string dataKey)
            => new LocalFileAddressProvider(fileReader, filePath, dataKey);

        /// <summary>
        /// Creates an <see cref="IAddressProvider"/> that loads addresses from a cloud storage service.
        /// </summary>
        /// <param name="cloudStorageManager">The cloud storage manager used to access cloud storage (e.g., AWS, Azure, Google).</param>
        /// <param name="storageContainer">The name of the container, bucket, or equivalent in cloud storage.</param>
        /// <param name="fileName">The name of the file containing address data.</param>
        /// <returns>An <see cref="IAddressProvider"/> for cloud storage access.</returns>
        public static IAddressProvider CreateCloudAddressProvider(ICloudStorageManager cloudStorageManager, string storageContainer, string fileName)
            => new CloudAddressProvider(cloudStorageManager, storageContainer, fileName);
    }
}
