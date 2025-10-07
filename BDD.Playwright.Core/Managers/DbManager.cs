namespace BDD.Playwright.Core.Managers
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Threading.Tasks;
    using BDD.Playwright.Core.Loggers;
    using Microsoft.Data.SqlClient;

    /// <summary>
    /// Provides methods for interacting with a SQL Server database, including executing queries, stored procedures, and managing policy data.
    /// Uses Microsoft.Data.SqlClient for database connectivity.
    /// </summary>
    public class DBManager
    {
        /// <summary>
        /// The connection string for the database. Set this value appropriately before use.
        /// </summary>
        private static readonly string ConnectionString = string.Empty; // Set your connection string here

        /// <summary>
        /// Initializes a new instance of the <see cref="DBManager"/> class.
        /// </summary>
        public DBManager()
        {
        }

        /// <summary>
        /// Retrieves a policy number from the database based on feature, scenario, and environment.
        /// </summary>
        /// <param name="featureName">The feature name.</param>
        /// <param name="scenarioName">The scenario name.</param>
        /// <param name="environment">The environment name.</param>
        /// <returns>The policy number as a string, or empty if not found.</returns>
        public static async Task<string> GetPolicyAsync(string featureName, string scenarioName, string environment)
        {
            var policyNumber = string.Empty;
            var query = "SELECT TOP 1 [DataValue] FROM [dbo].[TR_DCODQA] WHERE [DataKey] = @DataKey AND [IsUsed] = 0 AND [Environment] = @Environment AND [ScenarioName] = @ScenarioName AND [FeatureName] = @FeatureName";

            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DataKey", "PolicyNumber");
                command.Parameters.AddWithValue("@Environment", environment);
                command.Parameters.AddWithValue("@ScenarioName", scenarioName);
                command.Parameters.AddWithValue("@FeatureName", featureName);

                using var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    policyNumber = reader["DataValue"].ToString();
                }
            }
            catch (Exception ex)
            {
                CustomLogger.WriteLine(ex.Message);
                throw;
            }

            return policyNumber;
        }

        /// <summary>
        /// Inserts a new policy number into the database.
        /// </summary>
        /// <param name="policyNumber">The policy number to insert.</param>
        /// <param name="featureName">The feature name.</param>
        /// <param name="scenarioName">The scenario name.</param>
        /// <param name="environment">The environment name.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task SetPolicyAsync(string policyNumber, string featureName, string scenarioName, string environment)
        {
            var query = "INSERT INTO [dbo].[TR_DCODQA] ([FeatureName], [ScenarioName], [Environment], [DataKey], [DataValue], [IsUsed], [DateCreated], [DateUsed]) VALUES (@FeatureName, @ScenarioName, @Environment, @DataKey, @DataValue, 0, GETDATE(), GETDATE())";

            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FeatureName", featureName);
                command.Parameters.AddWithValue("@ScenarioName", scenarioName);
                command.Parameters.AddWithValue("@Environment", environment);
                command.Parameters.AddWithValue("@DataKey", "PolicyNumber");
                command.Parameters.AddWithValue("@DataValue", policyNumber);

                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                CustomLogger.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Updates the usage status of a policy number in the database.
        /// </summary>
        /// <param name="policyNumber">The policy number to update.</param>
        /// <param name="featureName">The feature name.</param>
        /// <param name="scenarioName">The scenario name.</param>
        /// <param name="environment">The environment name.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task UpdatePolicyAsync(string policyNumber, string featureName, string scenarioName, string environment)
        {
            var query = "UPDATE [dbo].[TR_DCODQA] SET [IsUsed] = 1, [DateUsed] = GETDATE() WHERE [DataValue] = @DataValue AND [IsUsed] = 0 AND [Environment] = @Environment AND [ScenarioName] = @ScenarioName AND [FeatureName] = @FeatureName";

            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DataValue", policyNumber);
                command.Parameters.AddWithValue("@Environment", environment);
                command.Parameters.AddWithValue("@ScenarioName", scenarioName);
                command.Parameters.AddWithValue("@FeatureName", featureName);

                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                CustomLogger.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Opens a new SQL connection asynchronously.
        /// </summary>
        /// <param name="connectionString">The connection string to use.</param>
        /// <returns>An open <see cref="SqlConnection"/> or null if connection fails.</returns>
        public static async Task<SqlConnection> DBConnectAsync(string connectionString)
        {
            try
            {
                var sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                return sqlConnection;
            }
            catch (Exception e)
            {
                CustomLogger.WriteLine("ERROR :: " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// Closes the provided SQL connection.
        /// </summary>
        /// <param name="sqlConnection">The open SQL connection to close.</param>
        public static void DBClose(SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection?.Close();
            }
            catch (Exception e)
            {
                CustomLogger.WriteLine("ERROR :: " + e.Message);
            }
        }

        /// <summary>
        /// Executes a SQL query asynchronously and returns the result as a DataTable.
        /// </summary>
        /// <param name="sqlConnection">An open SQL connection.</param>
        /// <param name="queryString">The SQL query to execute.</param>
        /// <returns>A <see cref="DataTable"/> containing the query results, or null if an error occurs.</returns>
        public static async Task<DataTable> ExecuteQueryAsync(SqlConnection sqlConnection, string queryString)
        {
            DataSet dataset = new();
            try
            {
                if (sqlConnection == null || sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
                {
                    await sqlConnection.OpenAsync();
                }

                using (var dataAdaptor = new SqlDataAdapter(queryString, sqlConnection))
                {
                    dataAdaptor.SelectCommand.CommandType = CommandType.Text;
                    dataAdaptor.Fill(dataset, "table");
                }

                return dataset.Tables["table"];
            }
            catch (Exception e)
            {
                CustomLogger.WriteLine("ERROR :: " + e.Message);
                return null;
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }
        }

        /// <summary>
        /// Executes a stored procedure with parameters and returns the result as a DataTable.
        /// </summary>
        /// <param name="conn">An open SQL connection.</param>
        /// <param name="procName">The name of the stored procedure to execute.</param>
        /// <param name="parameters">A hashtable of parameters for the stored procedure.</param>
        /// <returns>A <see cref="DataTable"/> containing the results, or null if an error occurs.</returns>
        public static DataTable ExecuteProcWithParamsDTAsync(SqlConnection conn, string procName, Hashtable parameters)
        {
            var dataSet = new DataSet();
            try
            {
                using (var dataAdaptor = new SqlDataAdapter(procName, conn))
                {
                    dataAdaptor.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        foreach (DictionaryEntry de in parameters)
                        {
                            var sp = new SqlParameter(de.Key.ToString(), de.Value.ToString());
                            dataAdaptor.SelectCommand.Parameters.Add(sp);
                        }
                    }

                    dataAdaptor.Fill(dataSet, "table");
                }

                return dataSet.Tables["table"];
            }
            catch (Exception e)
            {
                CustomLogger.WriteLine("ERROR :: " + e.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
