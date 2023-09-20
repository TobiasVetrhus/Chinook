using Microsoft.Data.SqlClient;

namespace Chinook.Repositories
{
    public class ConnectionStringHelper
    {
        /// <summary>
        /// Retrieves the connection string for the Chinook database.
        /// </summary>
        /// <returns>
        /// A string representing the connection string to the Chinook database.
        /// </returns> 
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "N-NO-01-05-2220\\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.TrustServerCertificate = true;
            return connectionStringBuilder.ConnectionString;
        }
    }
}
