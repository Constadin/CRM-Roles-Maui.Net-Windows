using CRM.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Configuration.Services
{
    public class DatabaseConnectionProvider : IDatabaseConnectionProvider
    {
        private readonly string? _ConnectionString;

        public DatabaseConnectionProvider()
        {
            // Load the appsettings.json configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Read the relative connection string path from appsettings.json
            var relativePath = configuration["AppSettings:ConnectionString"];

            if (string.IsNullOrWhiteSpace(relativePath))
            {
                throw new InvalidOperationException("Το ConnectionString είναι κενό.");
            }

            // Combine the runtime output path with the relative database path
            var runtimeBasePath = AppDomain.CurrentDomain.BaseDirectory;
            var dbPath = Path.Combine(runtimeBasePath, relativePath);

            // Ensure the database file exists
            if (!File.Exists(dbPath))
            {
                throw new FileNotFoundException($"The database file does not exist at the specified path: {dbPath}");
            }
            // Set the SQLite connection string
            this._ConnectionString = $"Data Source={dbPath}";
        }

        public string GetConnectionString()
        {
            if (this._ConnectionString == null)
            {
                throw new InvalidOperationException("Connection string is not set.");
            }

            return this._ConnectionString;
        }

    }
}
