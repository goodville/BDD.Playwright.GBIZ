namespace BDD.Playwright.Core.Helpers
{
    using System;
    using System.Linq;
    using Reqnroll;

    /// <summary>
    /// Provides helper methods for validating, formatting, and converting Reqnroll DataTables.
    /// Useful for test automation scenarios where table data needs to be validated, logged, or transformed.
    /// </summary>
    /// <remarks>
    /// <para>
    /// These methods assist with common DataTable operations in BDD scenarios, such as checking for required columns,
    /// formatting tables for readable logging, and converting Reqnroll tables to <see cref="System.Data.DataTable"/> for further processing.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// // Validate required columns in a DataTable row
    /// DataTableHelper.ValidateDataTableRowHeaders(row, new[] { "FirstName", "LastName" });
    ///
    /// // Format a table for logging
    /// string logOutput = DataTableHelper.FormatTableForLogging(table);
    ///
    /// // Convert a Reqnroll Table to a DataTable
    /// var dataTable = DataTableHelper.ConvertTableToDataTable(table, "USA Personal Auto");
    /// </code>
    /// </example>
    public class DataTableHelper
    {
        /// <summary>
        /// Checks if all required columns are present in the specified Reqnroll DataTable row.
        /// </summary>
        /// <param name="row">The DataTable row to validate.</param>
        /// <param name="requiredColumns">An array of required column headers.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if any required column is missing from the row.
        /// </exception>
        public static void ValidateDataTableRowHeaders(DataTableRow row, string[] requiredColumns)
        {
            foreach (var column in requiredColumns)
            {
                if (!row.ContainsKey(column))
                {
                    throw new ArgumentException($"DataTable is missing required column: {column}");
                }
            }
        }

        /// <summary>
        /// Formats a Reqnroll <see cref="Table"/> as a tab-separated string for logging purposes.
        /// </summary>
        /// <param name="table">The table to format.</param>
        /// <returns>
        /// A string representation of the table, or "No data to display." if the table is null or empty.
        /// </returns>
        public static string FormatTableForLogging(Table table)
        {
            if (table == null || table.RowCount == 0)
            {
                return "No data to display.";
            }

            var output = string.Join("\t", table.Header) + "\n";

            foreach (var row in table.Rows)
            {
                output += string.Join("\t", table.Header.Select(h => row[h])) + "\n";
            }

            return output;
        }

        /// <summary>
        /// Converts a Reqnroll <see cref="Table"/> to a <see cref="System.Data.DataTable"/>.
        /// For the product "USA Personal Auto", skips the first two rows of the table.
        /// </summary>
        /// <param name="table">The Reqnroll table to convert.</param>
        /// <param name="productName">The product name, used to determine if any rows should be skipped.</param>
        /// <returns>A <see cref="System.Data.DataTable"/> containing the table data.</returns>
        public static System.Data.DataTable ConvertTableToDataTable(Table table, string productName)
        {
            var dataTable = new System.Data.DataTable();

            foreach (var header in table.Header)
            {
                dataTable.Columns.Add(header);
            }

            foreach (var row in productName == "USA Personal Auto" ? table.Rows.Skip(2) : table.Rows)
            {
                var dataRow = dataTable.NewRow();
                for (var i = 0; i < table.Header.Count; i++)
                {
                    dataRow[i] = row[i];
                }

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}
