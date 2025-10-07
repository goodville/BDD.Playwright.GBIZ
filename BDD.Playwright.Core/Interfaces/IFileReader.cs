namespace BDD.Playwright.Core.Interfaces
{
    /// <summary>
    /// Common interface for reading data from files.
    /// Implementations may provide support for reading and extracting values from structured data files such as JSON.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For example, <c>JsonReader</c> loads and caches JSON files, and retrieves values using a JSONPath key.
    /// </para>
    /// <para>
    /// Implementations may throw exceptions if the file does not exist or if the key is not found.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage with <c>JsonReader</c>:
    /// </para>
    /// <code language="csharp">
    /// IFileReader reader = new JsonReader("TestData");
    /// string value = reader.GetValue("addresses.json", "addressList[0].City");
    /// string optionalValue = reader.GetValue("data.json", "optional.field", "", true);
    /// </code>
    /// </example>
    public interface IFileReader
    {
        /// <summary>
        /// Gets a value from a file.
        /// For JSON implementations, <paramref name="key"/> is typically a JSONPath expression.
        /// </summary>
        /// <param name="filePath">Path to the file to read from, relative to the base directory or data folder.</param>
        /// <param name="key">Key or path to the desired data (e.g., JSONPath for JSON files).</param>
        /// <param name="propertyName">Property name (may be unused in some implementations).</param>
        /// <returns>The value as a string.</returns>
        /// <exception cref="System.IO.FileNotFoundException">
        /// Thrown if the specified file does not exist.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="filePath"/> or <paramref name="key"/> is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown if the key is not found in the file.
        /// </exception>
        string GetValue(string filePath, string key, string propertyName = "");

        /// <summary>
        /// Gets a value from a file with optional field support.
        /// For JSON implementations, <paramref name="key"/> is typically a JSONPath expression.
        /// </summary>
        /// <param name="filePath">Path to the file to read from, relative to the base directory or data folder.</param>
        /// <param name="key">Key or path to the desired data (e.g., JSONPath for JSON files).</param>
        /// <param name="propertyName">Property name (may be unused in some implementations).</param>
        /// <param name="isOptional">If true, returns empty string when key is not found instead of throwing exception.</param>
        /// <returns>The value as a string, or empty string if key not found and isOptional is true.</returns>
        /// <exception cref="System.IO.FileNotFoundException">
        /// Thrown if the specified file does not exist.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="filePath"/> or <paramref name="key"/> is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown if the key is not found in the file and isOptional is false.
        /// </exception>
        string GetOptionalValue(string filePath, string key, string propertyName = "", bool isOptional = true);
    }
}
