namespace BDD.Playwright.Core.Models.Configuration
{
    /// <summary>
    /// Configuration for PDF comparison service endpoints.
    /// </summary>
    public class PDFCompareUrlsConfig
    {
        /// <summary>
        /// Gets or sets the iTAP base URL for PDF comparison.
        /// </summary>
        public string ItapBaseUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Python server base URL for PDF comparison.
        /// </summary>
        public string PythonBaseUrl { get; set; } = string.Empty;
    }
}
