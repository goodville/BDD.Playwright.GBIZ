namespace BDD.Playwright.Core.Models.Configuration.FileSourceConfigurations
{
    /// <summary>
    /// Represents configuration settings for a round-robin database source.
    /// Used to specify the connection string and table name for round-robin state in a database.
    /// </summary>
    public class RoundRobinDatabaseConfig
    {
        /// <summary>
        /// Gets or sets the connection string for the database.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name of the table in the database.
        /// </summary>
        public string TableName { get; set; }
    }
}
