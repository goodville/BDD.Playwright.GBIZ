namespace BDD.Playwright.Core.Models.Configuration.FileSourceConfigurations
{
    /// <summary>
    /// Represents configuration settings for retrieving address data from a database source.
    /// Used to specify the connection string, table name, and data key for extracting address data from a database.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This configuration is typically used by address providers that load address lists from relational databases.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage in configuration:
    /// </para>
    /// <code language="json">
    /// {
    ///   "AddressLists": {
    ///     "MyDatabaseList": {
    ///       "Source": "Database",
    ///       "DatabaseConfig": {
    ///         "ConnectionString": "Server=myServer;Database=myDb;User Id=myUser;Password=myPass;",
    ///         "TableName": "Addresses",
    ///         "DataKey": "addressList"
    ///       }
    ///     }
    ///   }
    /// }
    /// </code>
    /// </example>
    public class AddressDatabaseConfig
    {
        /// <summary>
        /// Gets or sets the connection string for the database.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name of the table in the database containing address data.
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the JSON data key to extract from the database (if applicable).
        /// </summary>
        public string DataKey { get; set; }
    }
}