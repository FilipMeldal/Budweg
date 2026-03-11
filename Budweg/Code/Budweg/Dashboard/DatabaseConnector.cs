using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Dashboard
{
    public abstract class DatabaseConnector
    {
        protected readonly string connectionString;

        public DatabaseConnector()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            connectionString = config.GetConnectionString("MyDBConnection");
        }
    }
}
