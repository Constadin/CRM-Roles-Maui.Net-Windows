using CRM.Abstractions.Services;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace CRM.Infrastructure.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        #region Private Fields

        private readonly IDatabaseConnectionProvider _DatabaseConnectionProvider;

        #endregion

        public AuthenticateService(IDatabaseConnectionProvider databaseConnectionProvider)
        {
            this._DatabaseConnectionProvider = databaseConnectionProvider;
        }


        public async Task<string?> AuthenticateAsync(string username, string password)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(this._DatabaseConnectionProvider.GetConnectionString()))
                {
                    
                    // Ερώτηση SQL με Dapper και χρήση παραμέτρων
                    var query = @"
                        SELECT ts.TypeOfStoreName 
                        FROM Owners ow
                        INNER JOIN TypeOfStores ts ON ow.TypeOfStoreID = ts.TypeOfStoreID
                        WHERE ow.Username = @Username AND ow.Password = @Password";

                    // Εκτέλεση με Dapper
                    var storeName = await cnn.QueryFirstOrDefaultAsync<string>(query, new { Username = username, Password = password });

                    return storeName; // Επιστροφή  κατηγορίας του καταστήματος αν βρεθεί
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Σφάλμα κατά την αυθεντικοποίηση: {ex.Message}");
                return null;
            }
        }

    }
}
