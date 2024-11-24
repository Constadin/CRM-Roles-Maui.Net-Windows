using CRM.Abstractions.Interfaces;
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
    public class OwnerRepositoryGRUD : IRepositoryGRUD<Owner>
    {
        private readonly GenericRepositoryGRUD<Owner> _GenericRepository;

        public OwnerRepositoryGRUD(IServiceProvider serviceProvider)
        {
            this._GenericRepository = new GenericRepositoryGRUD<Owner>(serviceProvider);
        }

        public List<Owner> LoadEntities()
        {
            return this._GenericRepository.LoadEntities();
        }

        public void SaveEntity(Owner owner)
        {
            this._GenericRepository.SaveEntity(owner);
        }

        public void UpdateEntity(Owner owner)
        {
            this._GenericRepository.UpdateEntity(owner);
        }

        public void DeleteEntity(int id)
        {
            this._GenericRepository.DeleteEntity(id);
        }


    }
}
