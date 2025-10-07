namespace BDD.Playwright.Core.Helpers
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using BDD.Playwright.Core.Interfaces;
    using BDD.Playwright.Core.Loggers;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Provides helper methods for reading JSON test data files using the Newtonsoft library.
    /// Supports thread-safe caching of loaded JSON files for efficient parallel test execution.
    /// Implements <see cref="IFileReader"/> to allow retrieval of values using JSONPath expressions.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class is typically used to read structured test data from JSON files in BDD scenarios.
    /// It caches loaded files in memory for performance and thread safety, and logs a warning if a requested key is not found.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// IFileReader reader = new JsonReader("TestData");
    /// string city = reader.GetValue("addresses.json", "addressList[0].City");
    /// </code>
    /// </example>
    internal class JsonReader : IFileReader
    {
        /// <summary>
        /// Thread-safe dictionary to store and cache JSON test data files.
        /// Uses the file path as the key and a lazy-loaded <see cref="JObject"/> as the value.
        /// </summary>
        private static readonly ConcurrentDictionary<string, Lazy<JObject>> CachedJsonFiles = new ();
        private readonly string baseFilePath;
        private JObject jsonData;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonReader"/> class with a relative file path.
        /// </summary>
        /// <param name="relativeFilePath">Relative path from the base directory to the folder containing JSON test data files.</param>
        public JsonReader(string relativeFilePath)
        {
            baseFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);
        }

        /// <summary>
        /// Retrieves a value from a JSON test data file using a JSONPath key.
        /// </summary>
        /// <param name="filePath">Path to the JSON file, relative to the base data folder.</param>
        /// <param name="key">JSONPath expression to the desired data in the file.</param>
        /// <param name="propertyName">Unused parameter (for interface compatibility).</param>
        /// <returns>The value as a string.</returns>
        /// <exception cref="FileNotFoundException">Thrown if the specified JSON file does not exist.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="filePath"/> or <paramref name="key"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the key is not found in the JSON file.</exception>
        public string GetValue(string filePath, string key, string propertyName = "")
        {
            var fullPath = Path.Combine(baseFilePath, filePath);
            jsonData = LoadJson(fullPath);
            var value = jsonData.SelectToken(key);

            if (value == null)
            {
                CustomLogger.WriteLine($"[Warning] Key '{key}' not found in file: {filePath}");
                throw new InvalidOperationException($"Key '{key}' not found in JSON file: {filePath}");
            }

            return value.ToString();
        }

        /// <summary>
        /// Retrieves a value from a JSON test data file using a JSONPath key with optional field support.
        /// </summary>
        /// <param name="filePath">Path to the JSON file, relative to the base data folder.</param>
        /// <param name="key">JSONPath expression to the desired data in the file.</param>
        /// <param name="propertyName">Unused parameter (for interface compatibility).</param>
        /// <param name="isOptional">If true, returns empty string when key is not found instead of throwing exception.</param>
        /// <returns>The value as a string, or empty string if key not found and isOptional is true.</returns>
        /// <exception cref="FileNotFoundException">Thrown if the specified JSON file does not exist.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="filePath"/> or <paramref name="key"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the key is not found in the JSON file and isOptional is false.</exception>
        public string GetOptionalValue(string filePath, string key, string propertyName = "", bool isOptional = true)
        {
            var fullPath = Path.Combine(baseFilePath, filePath);
            jsonData = LoadJson(fullPath);
            var value = jsonData.SelectToken(key);

            if (value == null)
            {
                if (isOptional)
                {
                    CustomLogger.WriteLine($"[Info] Optional key '{key}' not found in file: {filePath} - returning empty string");
                    return string.Empty;
                }
                else
                {
                    CustomLogger.WriteLine($"[Warning] Required key '{key}' not found in file: {filePath}");
                    throw new InvalidOperationException($"Key '{key}' not found in JSON file: {filePath}");
                }
            }

            return value.ToString();
        }

        /// <summary>
        /// Reads a JSON file into a <see cref="JObject"/> if it exists, using the cache if available.
        /// </summary>
        /// <param name="filePath">Full file path to the JSON file.</param>
        /// <returns>A <see cref="JObject"/> containing the contents of the specified JSON file.</returns>
        /// <exception cref="FileNotFoundException">Thrown if the requested file does not exist at the specified path.</exception>
        private static JObject LoadJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"JSON file not found: {filePath}");
            }

            var lazyJson = CachedJsonFiles.GetOrAdd(filePath, _ => new Lazy<JObject>(() =>
            {
                var jsonContent = File.ReadAllText(filePath);
                return JObject.Parse(jsonContent);
            }));

            return lazyJson.Value;
        }
    }
}
