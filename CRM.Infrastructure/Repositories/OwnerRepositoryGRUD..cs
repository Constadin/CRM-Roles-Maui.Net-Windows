using CRM.Domain.Owners.Interfaces;
using CRM.Domain.Owners.Models;
using CRM.Infrastructure.Configuration.Services;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repositories
{
    public class OwnerRepositoryGRUD : IOwnerRepositoryGRUD
    {

        private readonly IDatabaseConnectionProvider _DatabaseConnectionProvider;

        public OwnerRepositoryGRUD(IServiceProvider serviceProvider)
        {
            this._DatabaseConnectionProvider = serviceProvider.GetRequiredService<IDatabaseConnectionProvider>();

        }
        public List<Owner> LoadOwners()
        {
            using (IDbConnection cnn = new SQLiteConnection(this._DatabaseConnectionProvider.GetConnectionString()))
            {
                var responseQuery = cnn.Query<Owner>("Select * From Owners", new DynamicParameters());

                return responseQuery.ToList();
            }

        }
        public void SaveOwner(Owner owner)
        {
            using (IDbConnection cnn = new SQLiteConnection(this._DatabaseConnectionProvider.GetConnectionString()))
            {
                cnn.Execute("insert into Owners (FirstName, LastName, PhoneNumber) values (@FirstName, @LastName, @PhoneNumber)", owner);
            }

        }
    }
}
