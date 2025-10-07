namespace BDD.Playwright.Core.Managers.CloudStorage
{
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Azure;
    using Azure.Storage.Blobs;
    using BDD.Playwright.Core.Interfaces;

    /// <summary>
    /// Provides methods to upload, download, and delete files from AWS S3 Storage.
    /// Implements <see cref="ICloudStorageManager"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <b>DownloadFileAsStringAsync</b> and <b>DownloadFileAsBytesAsync</b> return <c>string.Empty</c> or <c>null</c> if the file is not found.
    /// <b>UploadFileAsync</b> and <b>DeleteFileAsync</b> may throw provider-specific exceptions if the operation fails.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// ICloudStorageManager storageManager = new AzureBlobStorageManager();
    /// await storageManager.UploadFileAsync("my-bucket", "file.txt", "Hello, world!");
    /// string content = await storageManager.DownloadFileAsStringAsync("my-bucket", "file.txt");
    /// byte[] bytes = await storageManager.DownloadFileAsBytesAsync("my-bucket", "file.txt");
    /// await storageManager.DeleteFileAsync("my-bucket", "file.txt");
    /// </code>
    /// </example>
    internal class AzureBlobStorageManager : ICloudStorageManager
    {
        private readonly string connectionString;
        private readonly BlobServiceClient blobServiceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureBlobStorageManager"/> class.
        /// Uses Azure connection string.
        /// </summary>
        /// <param name="connectionString">Connection string for Azure Devops Blob Storage.</param>
        public AzureBlobStorageManager(string connectionString)
        {
            this.connectionString = connectionString;
            blobServiceClient = new BlobServiceClient(connectionString);
        }

        /// <inheritdoc/>
        public async Task DeleteFileAsync(string container, string fileName)
        {
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(container);
            var blobClient = blobContainerClient.GetBlobClient(fileName);

            await blobClient.DeleteAsync();
        }

        /// <inheritdoc/>
        public async Task<string> DownloadFileAsStringAsync(string container, string fileName)
        {
            try
            {
                var blobContainerClient = blobServiceClient.GetBlobContainerClient(container);
                var blobClient = blobContainerClient.GetBlobClient(fileName);

                using var blobStream = new MemoryStream();
                var response = await blobClient.DownloadToAsync(blobStream);

                blobStream.Position = 0; // Reset stream position to the beginning before reading

                using var reader = new StreamReader(blobStream);
                var content = reader.ReadToEnd();
                return content;
            }
            catch (RequestFailedException rex) when (rex.Status == 404 && rex.ErrorCode == "BlobNotFound")
            {
                return string.Empty;
            }
        }

        /// <inheritdoc/>
        public async Task<byte[]> DownloadFileAsBytesAsync(string container, string fileName)
        {
            try
            {
                var blobContainerClient = blobServiceClient.GetBlobContainerClient(container);
                var blobClient = blobContainerClient.GetBlobClient(fileName);

                var response = await blobClient.DownloadContentAsync();
                return response.Value.Content.ToArray();
            }
            catch
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public async Task UploadFileAsync(string container, string fileName, string content)
        {
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(container);
            var blobClient = blobContainerClient.GetBlobClient(fileName);

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            await blobClient.UploadAsync(stream, overwrite: true);
        }
    }
}
