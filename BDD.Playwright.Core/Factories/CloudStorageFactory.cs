namespace BDD.Playwright.Core.Factories
{
    using BDD.Playwright.Core.Interfaces;
    using BDD.Playwright.Core.Managers.CloudStorage;

    /// <summary>
    /// Factory for creating <see cref="ICloudStorageManager"/> instances for different cloud storage providers.
    /// Supports Azure Blob Storage, Amazon S3, and Google Cloud Storage.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this factory to abstract the instantiation of cloud storage managers, allowing test code to remain agnostic to the underlying cloud provider.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// // Create an Azure Blob Storage manager
    /// ICloudStorageManager azureManager = CloudStorageFactory.CreateAzureStorageManager();
    ///
    /// // Create an Amazon S3 Storage manager
    /// ICloudStorageManager awsManager = CloudStorageFactory.CreateAmazonStorageManger();
    ///
    /// // Create a Google Cloud Storage manager
    /// ICloudStorageManager googleManager = CloudStorageFactory.CreateGoogleStorageManager();
    /// </code>
    /// </example>
    public class CloudStorageFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="ICloudStorageManager"/> for Azure Blob Storage.
        /// </summary>
        /// <returns>An <see cref="ICloudStorageManager"/> for Azure Blob Storage.</returns>
        /// <param name="connectionString">Azure Blob Storage connection string.</param>
        public static ICloudStorageManager CreateAzureStorageManager(string connectionString) => new AzureBlobStorageManager(connectionString);

        /// <summary>
        /// Creates an instance of <see cref="ICloudStorageManager"/> for Amazon S3 Storage.
        /// </summary>
        /// <returns>An <see cref="ICloudStorageManager"/> for Amazon S3 Storage.</returns>
        public static ICloudStorageManager CreateAmazonStorageManger() => new AwsBlobStorageManager();

        /// <summary>
        /// Creates an instance of <see cref="ICloudStorageManager"/> for Google Cloud Storage.
        /// </summary>
        /// <returns>An <see cref="ICloudStorageManager"/> for Google Cloud Storage.</returns>
        public static ICloudStorageManager CreateGoogleStorageManager() => new GoogleCloudStorageManager();
    }
}
