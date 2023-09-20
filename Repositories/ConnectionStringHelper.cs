using Microsoft.Data.SqlClient;

namespace Chinook.Repositories
{
    public class ConnectionStringHelper
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "N-NO-01-05-2220\\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.TrustServerCertificate = true;
            //connectionStringBuilder.Encrypt = false; Disabling SSL encryption for testing and development. Not recommended for production.
            return connectionStringBuilder.ConnectionString;
        }
    }
}
