namespace BDD.Playwright.Core.Managers.CloudStorage
{
    using System.IO;
    using System.Security.AccessControl;
    using System.Text;
    using System.Threading.Tasks;
    using BDD.Playwright.Core.Interfaces;
    using Google.Cloud.Storage.V1;

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
    /// ICloudStorageManager storageManager = new GoogleCloudStorageManager();
    /// await storageManager.UploadFileAsync("my-bucket", "file.txt", "Hello, world!");
    /// string content = await storageManager.DownloadFileAsStringAsync("my-bucket", "file.txt");
    /// byte[] bytes = await storageManager.DownloadFileAsBytesAsync("my-bucket", "file.txt");
    /// await storageManager.DeleteFileAsync("my-bucket", "file.txt");
    /// </code>
    /// </example>
    internal class GoogleCloudStorageManager : ICloudStorageManager
    {
        private readonly StorageClient storageClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleCloudStorageManager"/> class.
        /// Uses GOOGLE_APPLICATION_CREDENTIALS env variable.
        /// </summary>
        public GoogleCloudStorageManager()
        {
            storageClient = StorageClient.Create();
        }

        /// <inheritdoc/>
        public async Task DeleteFileAsync(string bucket, string fileName) => await storageClient.DeleteObjectAsync(bucket, fileName);

        /// <inheritdoc/>
        public async Task<string> DownloadFileAsStringAsync(string bucket, string fileName)
        {
            try
            {
                using var stream = new MemoryStream();
                await storageClient.DownloadObjectAsync(bucket, fileName, stream);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch (Google.GoogleApiException ex) when (ex.HttpStatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return string.Empty;
            }
        }

        /// <inheritdoc/>
        public async Task<byte[]> DownloadFileAsBytesAsync(string bucket, string fileName)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                await storageClient.DownloadObjectAsync(bucket, fileName, memoryStream);
                return memoryStream.ToArray();
            }
            catch
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public async Task UploadFileAsync(string bucket, string fileName, string content)
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            await storageClient.UploadObjectAsync(bucket, fileName, null, stream);
        }
    }
}