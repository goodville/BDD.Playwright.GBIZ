namespace BDD.Playwright.Core.Factories
{
    using BDD.Playwright.Core.Interfaces;

    /// <summary>
    /// Factory for creating <see cref="IFileReader"/> instances for reading structured data files.
    /// Currently supports creation of JSON file readers.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this factory to abstract the instantiation of file readers, allowing test code to remain agnostic to the underlying file format or reader implementation.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// // Create a JSON file reader for the "TestData" directory
    /// IFileReader reader = FileReaderFactory.CreateJsonFileReader("TestData");
    /// string value = reader.GetValue("addresses.json", "addressList[0].City");
    /// </code>
    /// </example>
    public class FileReaderFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="IFileReader"/> for reading JSON files.
        /// </summary>
        /// <param name="relativeFilePath">File path relative to the base directory of the primary assembly (e.g., "TestData").</param>
        /// <returns>An <see cref="IFileReader"/> for reading JSON files.</returns>
        public static IFileReader CreateJsonFileReader(string relativeFilePath) => new Helpers.JsonReader(relativeFilePath);
    }
}