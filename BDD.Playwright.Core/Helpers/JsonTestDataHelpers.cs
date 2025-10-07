namespace BDD.Playwright.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    using Reqnroll;

    /// <summary>
    /// Provides static helper methods for manipulating JSON test data in BDD scenarios.
    /// Supports updating <see cref="JObject"/> test data with values from Reqnroll DataTables, ScenarioContext, and FeatureContext.
    /// Includes utilities for date formatting, state abbreviation lookup, and safe value retrieval.
    /// </summary>
    /// <remarks>
    /// <para>
    /// These helpers are designed to streamline test data setup and manipulation in automated acceptance tests.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// // Set a date 5 days from now in MM/dd/yyyy format
    /// string futureDate = JsonTestDataHelpers.SetDate("5");
    ///
    /// // Replace values in a JObject using a DataTable
    /// JsonTestDataHelpers.ReplaceData(table, testData);
    ///
    /// // Replace values in a JObject using ScenarioContext
    /// JsonTestDataHelpers.ReplaceData(table, testData, scenarioContext);
    ///
    /// // Get a state abbreviation from test data
    /// string abbr = JsonTestDataHelpers.GetStateAbbrivationAsync(testData);
    ///
    /// // Safely get a string property from a JObject
    /// string value = testData.GetSafeString("SomeKey");
    /// </code>
    /// </example>
    public static class JsonTestDataHelpers
    {
        /// <summary>
        /// Returns a date string in MM/dd/yyyy format by adding or subtracting days from the current date.
        /// </summary>
        /// <param name="dateModifier">The number of days to add (positive) or subtract (negative) from the current date.</param>
        /// <returns>A date string in MM/dd/yyyy format.</returns>
        public static string SetDate(string dateModifier) => DateTime.Now.AddDays(int.Parse(dateModifier)).ToString("MM/dd/yyyy");

        /// <summary>
        /// Updates a <see cref="JObject"/> with key-value pairs from a Reqnroll <see cref="DataTable"/>.
        /// If a value is "null", the key is removed from the JSON object.
        /// Supports updating nested properties using JSONPath syntax in the "Key" column.
        /// </summary>
        /// <param name="table">A DataTable with "Key" and "Value" columns.</param>
        /// <param name="testData">The <see cref="JObject"/> to update.</param>
        /// <exception cref="Exception">Thrown if a key from the table is not found in the JSON object when using JSONPath.</exception>
        public static void ReplaceData(DataTable table, JObject testData)
        {
            DataTableHelper.ValidateDataTableRowHeaders(table.Rows.First(), ["Key", "Value"]);
            foreach (var row in table.Rows)
            {
                if (row["Key"].Contains('.'))
                {
                    var valueToken = testData.SelectToken(row["Key"]);
                    if (valueToken != null)
                    {
                        valueToken.Replace(row["Value"]);
                    }
                    else
                    {
                        throw new Exception($"No JSON Object found using JSON Path: {row["Key"]}");
                    }
                }
                else
                {
                    if (testData.ContainsKey(row["Key"]))
                    {
                        if (row["Value"] == "null")
                        {
                            testData.Remove(row["Key"]);
                        }
                        else
                        {
                            testData[row["Key"]] = row["Value"];
                        }
                    }
                    else
                    {
                        testData.Add(row["Key"], row["Value"]);
                    }
                }
            }
        }

        /// <summary>
        /// Updates a <see cref="JObject"/> with values from a Reqnroll <see cref="DataTable"/> and <see cref="ScenarioContext"/>.
        /// The "Context Value" column in the table specifies the key to retrieve from the scenario context.
        /// If the value is "null", the key is removed from the JSON object.
        /// </summary>
        /// <param name="table">A DataTable with "Key" and "Context Value" columns.</param>
        /// <param name="testData">The <see cref="JObject"/> to update.</param>
        /// <param name="scenarioContext">The scenario context to retrieve values from.</param>
        /// <exception cref="Exception">Thrown if a key from the table is not found in the JSON object when using JSONPath.</exception>
        public static void ReplaceData(DataTable table, JObject testData, ScenarioContext scenarioContext)
        {
            DataTableHelper.ValidateDataTableRowHeaders(table.Rows.First(), ["Key", "Context Value"]);

            foreach (var row in table.Rows)
            {
                if (row["Key"].Contains('.'))
                {
                    var valueToken = testData.SelectToken(row["Key"]);
                    if (valueToken != null)
                    {
                        valueToken.Replace(scenarioContext.Get<string>(row["Context Value"]));
                    }
                    else
                    {
                        throw new Exception($"No JSON Object found using JSON Path: {row["Key"]}");
                    }
                }
                else
                {
                    if (testData.ContainsKey(row["Key"]))
                    {
                        if (row["Context Value"] == "null")
                        {
                            testData.Remove(row["Key"]);
                        }
                        else
                        {
                            testData[row["Key"]] = scenarioContext.Get<string>(row["Context Value"]);
                        }
                    }
                    else
                    {
                        testData.Add(row["Key"], scenarioContext.Get<string>(row["Context Value"]));
                    }
                }
            }
        }

        /// <summary>
        /// Updates a <see cref="JObject"/> with values from a Reqnroll <see cref="DataTable"/> and <see cref="FeatureContext"/>.
        /// The "Context Value" column in the table specifies the key to retrieve from the feature context.
        /// If the value is "null", the key is removed from the JSON object.
        /// </summary>
        /// <param name="table">A DataTable with "Key" and "Context Value" columns.</param>
        /// <param name="testData">The <see cref="JObject"/> to update.</param>
        /// <param name="featureContext">The feature context to retrieve values from.</param>
        /// <exception cref="Exception">Thrown if a key from the table is not found in the JSON object when using JSONPath.</exception>
        public static void ReplaceData(DataTable table, JObject testData, FeatureContext featureContext)
        {
            DataTableHelper.ValidateDataTableRowHeaders(table.Rows.First(), ["Key", "Context Value"]);

            foreach (var row in table.Rows)
            {
                if (row["Key"].Contains('.'))
                {
                    var valueToken = testData.SelectToken(row["Key"]);
                    if (valueToken != null)
                    {
                        valueToken.Replace(featureContext.Get<string>(row["Context Value"]));
                    }
                    else
                    {
                        throw new Exception($"No JSON Object found using JSON Path: {row["Key"]}");
                    }
                }
                else
                {
                    if (testData.ContainsKey(row["Key"]))
                    {
                        if (row["Value"] == "null")
                        {
                            testData.Remove(row["Key"]);
                        }
                        else
                        {
                            testData[row["Key"]] = featureContext.Get<string>(row["Context Value"]);
                        }
                    }
                    else
                    {
                        testData.Add(row["Key"], featureContext.Get<string>(row["Context Value"]));
                    }
                }
            }
        }

        /// <summary>
        /// Returns the two-letter state abbreviation for the "State" property in the provided <see cref="JObject"/>.
        /// Throws an exception if the state is not recognized.
        /// </summary>
        /// <param name="testData">The <see cref="JObject"/> containing a "State" property.</param>
        /// <returns>The state abbreviation as a string.</returns>
        /// <exception cref="Exception">Thrown if the state value is not recognized.</exception>
        public static string GetStateAbbrivationAsync(JObject testData)
        {
            var stateCityMap = new Dictionary<string, string>
            {
                { "Texas", "TX" },
                { "California", "CA" },
                { "Alaska", "AK" },
                { "Florida", "FL" },
                { "Arizona", "AZ" },
            };

            var state = testData["State"].ToString();
            var stateAbbrivation = stateCityMap.ContainsKey(state) ? stateCityMap[state] : throw new Exception("Invalid state value");
            return stateAbbrivation;
        }

        /// <summary>
        /// Safely gets a string value from a <see cref="JObject"/> property, returning an empty string if the key is not found or the value is null.
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> to get the value from.</param>
        /// <param name="key">The key of the property.</param>
        /// <returns>The string value of the property, or <see cref="string.Empty"/> if the <see cref="JObject"/> is null, the property does not exist, or its value is null.</returns>
        public static string GetSafeString(this JObject jObject, string key) => jObject == null ? string.Empty : jObject[key]?.ToString() ?? string.Empty;
    }
}