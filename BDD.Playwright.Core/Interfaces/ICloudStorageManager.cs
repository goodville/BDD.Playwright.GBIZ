namespace BDD.Playwright.Core.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for working with cloud-based storage providers.
    /// Contains methods for uploading, downloading, and deleting files in cloud storage. (Upload also updates existing files by overwriting).
    /// Implementations include AWS S3, Azure Blob Storage, and Google Cloud Storage.
    /// This interface should be used for any interaction with cloud storage.
    /// Reasons to use cloud storage: storing files that can't be source controlled, storing files that need to change independently of the codebase, or storing large files that are not suitable for version control systems.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Implementations may handle missing files or containers differently:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <b>DownloadFileAsStringAsync</b> and <b>DownloadFileAsBytesAsync</b> return <c>string.Empty</c> or <c>null</c> if the file is not found.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <b>UploadFileAsync</b> and <b>DeleteFileAsync</b> may throw provider-specific exceptions if the operation fails.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// ICloudStorageManager storageManager = new AzureBlobStorageManager();
    /// await storageManager.UploadFileAsync("my-container", "file.txt", "Hello, world!");
    /// string content = await storageManager.DownloadFileAsStringAsync("my-container", "file.txt");
    /// byte[] bytes = await storageManager.DownloadFileAsBytesAsync("my-container", "file.txt");
    /// await storageManager.DeleteFileAsync("my-container", "file.txt");
    /// </code>
    /// </example>
    public interface ICloudStorageManager
    {
        /// <summary>
        /// Uploads a file to blob storage.
        /// </summary>
        /// <param name="container">The file container or bucket.</param>
        /// <param name="fileName">The file name.</param>
        /// <param name="content">The file content as a string.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="System.Exception">
        /// Thrown if the upload fails due to provider-specific errors (e.g., authentication, network, or permission issues).
        /// </exception>
        public Task UploadFileAsync(string container, string fileName, string content);

        /// <summary>
        /// Downloads a file from blob storage as a string.
        /// </summary>
        /// <param name="container">The file container or bucket.</param>
        /// <param name="fileName">The file name.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains the file content as a string,
        /// or <c>string.Empty</c> if the file is not found.
        /// </returns>
        /// <exception cref="System.Exception">
        /// Thrown if the download fails due to provider-specific errors (other than file not found).
        /// </exception>
        public Task<string> DownloadFileAsStringAsync(string container, string fileName);

        /// <summary>
        /// Downloads a file from blob storage as a byte array.
        /// </summary>
        /// <param name="container">The file container or bucket.</param>
        /// <param name="fileName">The file name.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains the file content as a byte array,
        /// or <c>null</c> if the file is not found.
        /// </returns>
        /// <exception cref="System.Exception">
        /// Thrown if the download fails due to provider-specific errors (other than file not found).
        /// </exception>
        public Task<byte[]> DownloadFileAsBytesAsync(string container, string fileName);

        /// <summary>
        /// Deletes a file from blob storage.
        /// </summary>
        /// <param name="container">The file container or bucket.</param>
        /// <param name="fileName">The file name.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="System.Exception">
        /// Thrown if the delete operation fails due to provider-specific errors (e.g., authentication, network, or permission issues).
        /// </exception>
        public Task DeleteFileAsync(string container, string fileName);
    }
}
