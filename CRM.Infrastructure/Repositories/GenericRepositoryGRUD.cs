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
        #region Private Filelds

        private readonly IDatabaseConnectionProvider _DatabaseConnectionProvider;

        #endregion

        #region Constructors
        public GenericRepositoryGRUD(IServiceProvider serviceProvider)
        {
            this._DatabaseConnectionProvider = serviceProvider.GetRequiredService<IDatabaseConnectionProvider>();
        }
        #endregion

        #region Public methods

        // Method to Load an entity of type T
        public List<T> LoadEntities()
        {
            using (IDbConnection cnn = new SQLiteConnection(this._DatabaseConnectionProvider.GetConnectionString()))
            {
                // Dynamically get the table name based on the type of T
                var tableName = typeof(T).Name + "s"; // Assume plural table names

                var query = $"SELECT * FROM {tableName}";

                var responseQuery = cnn.Query<T>(query, new DynamicParameters());

                return responseQuery.ToList();
            }
        }

        // Method to Save an entity of type T
        public void SaveEntity(T entity)
        {
            using (IDbConnection cnn = new SQLiteConnection(this._DatabaseConnectionProvider.GetConnectionString()))
            {
                // Dynamically generate the insert statement for the entity based on its properties
                var tableName = typeof(T).Name + "s"; // Assume plural table names
                                                      // Generate the query dynamically
                var properties = typeof(T).GetProperties().Where(p => p.Name != "OwnerId");

                var columns = string.Join(", ", properties.Select(p => p.Name));

                var parameters = string.Join(", ", properties.Select(p => "@" + p.Name));

                var query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

                cnn.Execute(query, entity);
            }
        }

        // Method to Update an entity of type T
        public void UpdateEntity(T entity)
        {
            using (IDbConnection cnn = new SQLiteConnection(this._DatabaseConnectionProvider.GetConnectionString()))
            {
                var tableName = typeof(T).Name + "s";  // Assuming plural table names

                var setClause = string.Join(", ", typeof(T).GetProperties().Select(p => $"{p.Name} = @{p.Name}"));

                // Assuming the entity has an Id property for identifying the record to update
                var query = $"UPDATE {tableName} SET {setClause} WHERE Id = @Id";

                cnn.Execute(query, entity);
            }
        }

        // Method to Delete an entity of type T by its Id
        public void DeleteEntity(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(this._DatabaseConnectionProvider.GetConnectionString()))
            {
                var tableName = typeof(T).Name + "s";  // Assuming plural table names

                var query = $"DELETE FROM {tableName} WHERE Id = @Id";

                cnn.Execute(query, new { Id = id });
            }
        }
        #endregion
    }
}
