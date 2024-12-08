using CRM.Infrastructure.Configuration.Services;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Abstractions.Repositories;
using CRM.Abstractions.Services;

namespace CRM.Infrastructure.Repositories
{
    public class GenericRepositoryGRUD<T> : IRepositoryGRUD<T> where T : class
    {
        #region Private Fields

        private readonly IDatabaseConnectionProvider _DatabaseConnectionProvider;

        #endregion

        #region Constractors
        public GenericRepositoryGRUD(IServiceProvider serviceProvider)
        {
            this._DatabaseConnectionProvider = serviceProvider.GetRequiredService<IDatabaseConnectionProvider>();
        }
        #endregion

        #region Public methods

        // Μέθοδος για φόρτωση οντοτήτων τύπου T
        public List<T> LoadEntities()
        {
            using (IDbConnection cnn = new SQLiteConnection(this._DatabaseConnectionProvider.GetConnectionString()))
            {
                // Δυναμικός προσδιορισμός του ονόματος του πίνακα βάσει του τύπου T
                var tableName = typeof(T).Name + "s"; // Υποθέτουμε πληθυντικά ονόματα πινάκων

                var query = $"SELECT * FROM {tableName}";

                var responseQuery = cnn.Query<T>(query, new DynamicParameters());

                return responseQuery.ToList();
            }
        }

        // Μέθοδος για αποθήκευση οντοτήτων τύπου T
        public void SaveEntity(T entity)
        {
            using (IDbConnection cnn = new SQLiteConnection(this._DatabaseConnectionProvider.GetConnectionString()))
            {
                // Δυναμική δημιουργία της δήλωσης εισαγωγής για την οντότητα βάσει των ιδιοτήτων της
                var tableName = typeof(T).Name + "s"; // Υποθέτουμε πληθυντικά ονόματα πινάκων

                var properties = typeof(T).GetProperties().Where(p => p.Name != "OwnerId");

                var columns = string.Join(", ", properties.Select(p => p.Name));

                var parameters = string.Join(", ", properties.Select(p => "@" + p.Name));

                var query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

                cnn.Execute(query, entity);
            }
        }

        // Μέθοδος για ενημέρωση οντοτήτων τύπου T
        public void UpdateEntity(T entity)
        {
            using (IDbConnection cnn = new SQLiteConnection(this._DatabaseConnectionProvider.GetConnectionString()))
            {
                var tableName = typeof(T).Name + "s";  // Υποθέτουμε πληθυντικά ονόματα πινάκων

                var setClause = string.Join(", ", typeof(T).GetProperties().Select(p => $"{p.Name} = @{p.Name}"));

                // Υποθέτουμε ότι η οντότητα διαθέτει ιδιότητα Id για την ταυτοποίηση της εγγραφής προς ενημέρωση
                var query = $"UPDATE {tableName} SET {setClause} WHERE Id = @Id";

                cnn.Execute(query, entity);
            }
        }

        // Μέθοδος για διαγραφή οντοτήτων τύπου T βάσει του Id
        public void DeleteEntity(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(this._DatabaseConnectionProvider.GetConnectionString()))
            {
                var tableName = typeof(T).Name + "s";  // Υποθέτουμε πληθυντικά ονόματα πινάκων

                var query = $"DELETE FROM {tableName} WHERE Id = @Id";

                cnn.Execute(query, new { Id = id });
            }
        }
        #endregion
    }
}
