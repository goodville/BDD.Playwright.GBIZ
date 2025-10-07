namespace BDD.Playwright.Core.Managers.CloudStorage
{
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Amazon.S3;
    using Amazon.S3.Model;
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
    /// ICloudStorageManager storageManager = new AwsBlobStorageManager();
    /// await storageManager.UploadFileAsync("my-bucket", "file.txt", "Hello, world!");
    /// string content = await storageManager.DownloadFileAsStringAsync("my-bucket", "file.txt");
    /// byte[] bytes = await storageManager.DownloadFileAsBytesAsync("my-bucket", "file.txt");
    /// await storageManager.DeleteFileAsync("my-bucket", "file.txt");
    /// </code>
    /// </example>
    internal class AwsBlobStorageManager : ICloudStorageManager
    {
        private readonly AmazonS3Client s3Client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AwsBlobStorageManager"/> class.
        /// Uses the default AWS credential provider chain.
        /// </summary>
        public AwsBlobStorageManager()
        {
            s3Client = new AmazonS3Client(); // Uses default AWS credential provider chain
        }

        /// <inheritdoc/>
        public async Task DeleteFileAsync(string bucket, string fileName) => await s3Client.DeleteObjectAsync(bucket, fileName);

        /// <inheritdoc/>
        public async Task<string> DownloadFileAsStringAsync(string bucket, string fileName)
        {
            try
            {
                var response = await s3Client.GetObjectAsync(bucket, fileName);
                using var reader = new StreamReader(response.ResponseStream);
                return await reader.ReadToEndAsync();
            }
            catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return string.Empty;
            }
        }

        /// <inheritdoc/>
        public async Task<byte[]> DownloadFileAsBytesAsync(string bucket, string fileName)
        {
            try
            {
                var response = await s3Client.GetObjectAsync(bucket, fileName);

                using var memoryStream = new MemoryStream();
                await response.ResponseStream.CopyToAsync(memoryStream);
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
            var request = new PutObjectRequest
            {
                BucketName = bucket,
                Key = fileName,
                InputStream = stream,
            };

            await s3Client.PutObjectAsync(request);
        }
    }
}
