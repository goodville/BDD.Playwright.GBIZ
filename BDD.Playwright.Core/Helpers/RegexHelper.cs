namespace BDD.Playwright.POM.Helpers
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides static helper methods for extracting numeric values from strings using regular expressions.
    /// Useful for parsing test output, UI text, or other data sources where numbers are embedded in strings.
    /// </summary>
    /// <remarks>
    /// <para>
    /// These methods are commonly used in test automation scenarios to extract integer or floating-point values from formatted strings.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// // Extract the first integer from a string
    /// string number = RegexHelper.RegexExtractIntegersFromString("Order #12345 completed.");
    /// // number == "12345"
    ///
    /// // Extract a floating point number from a string
    /// string price = RegexHelper.RegexExtractFloatingPointNumberFromString("Total: $1,234.56");
    /// // price == "1,234.56"
    /// </code>
    /// </example>
    public class RegexHelper
    {
        /// <summary>
        /// Extracts the first sequence of digits (integer) from the input string.
        /// </summary>
        /// <param name="input">The string to be searched.</param>
        /// <returns>The first integer found as a string.</returns>
        /// <exception cref="Exception">
        /// Thrown if no integer is found in the input string.
        /// </exception>
        public static string RegexExtractIntegersFromString(string input) => MatchRegex(input, @"\d+");

        /// <summary>
        /// Extracts the first floating point number (with optional thousands separators) from the input string.
        /// </summary>
        /// <param name="input">The string to be searched.</param>
        /// <returns>The first floating point number found as a string.</returns>
        /// <exception cref="Exception">
        /// Thrown if no floating point number is found in the input string.
        /// </exception>
        public static string RegexExtractFloatingPointNumberFromString(string input) => MatchRegex(input, @"(\d{1,3}(?:,\d{3})*\.\d+)");

        /// <summary>
        /// Returns the first substring in <paramref name="stringToSearch"/> that matches the given regular expression <paramref name="pattern"/>.
        /// If the pattern contains capturing groups, returns the first group's value; otherwise, returns the matched value.
        /// </summary>
        /// <param name="stringToSearch">The string to be searched.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <returns>The matched string.</returns>
        /// <exception cref="Exception">
        /// Thrown if no match is found in <paramref name="stringToSearch"/> for the given <paramref name="pattern"/>.
        /// </exception>
        public static string MatchRegex(string stringToSearch, string pattern)
        {
            var match = Regex.Match(stringToSearch, pattern);

            return !match.Success
                ? throw new Exception($"No match found in '{stringToSearch}' for the Regex pattern '{pattern}'")
                : match.Groups.Count > 1 ? match.Groups[1].Value : match.Value;
        }
    }
}
