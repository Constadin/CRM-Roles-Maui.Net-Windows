using CRM.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace CRM.Infrastructure.Configuration.Services
{
    public class DatabaseConnectionProvider : IDatabaseConnectionProvider
    {
        private readonly string _ConnectionString;
        private readonly ILogger<DatabaseConnectionProvider> _logger;

        public DatabaseConnectionProvider(ILogger<DatabaseConnectionProvider> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));

            try
            {
                // Φόρτωση του αρχείου διαμόρφωσης appsettings.json
                var configuration = LoadConfiguration();
                var relativePath = configuration["AppSettings:ConnectionString"];

                if (string.IsNullOrWhiteSpace(relativePath))
                {
                    throw new InvalidOperationException("Η ρύθμιση AppSettings:ConnectionString στο appsettings.json είναι κενή.");
                }

                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var dbPath = Path.Combine(basePath, relativePath);

                if (!File.Exists(dbPath))
                {
                    this._logger.LogInformation($"Το αρχείο της βάσης δεδομένων δεν υπάρχει στη διαδρομή: {dbPath}. Θα προσπαθήσουμε να το δημιουργήσουμε.");
                    Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);
                    File.Create(dbPath).Dispose(); // Δημιουργία του αρχείου
                }

                this._ConnectionString = $"Data Source={dbPath}";
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Σφάλμα κατά τη δημιουργία του connection string.");
                throw;
            }
        }

        public string GetConnectionString()
        {
            return this._ConnectionString;
        }

        private IConfiguration LoadConfiguration()
        {
            // Φορτώνουμε το αρχείο appsettings.json
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
