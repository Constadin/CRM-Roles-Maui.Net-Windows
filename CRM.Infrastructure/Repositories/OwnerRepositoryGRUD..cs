using CRM.Abstractions.Repositories;
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
            // Αρχικοποίηση του γενικού repository για οντότητες τύπου Owner
            this._GenericRepository = new GenericRepositoryGRUD<Owner>(serviceProvider);
        }

        public List<Owner> LoadEntities()
        {
            // Φόρτωση όλων των οντοτήτων τύπου Owner
            return this._GenericRepository.LoadEntities();
        }

        public void SaveEntity(Owner owner)
        {
            // Αποθήκευση μιας νέας οντότητας τύπου Owner
            this._GenericRepository.SaveEntity(owner);
        }

        public void UpdateEntity(Owner owner)
        {
            // Ενημέρωση μιας υπάρχουσας οντότητας τύπου Owner
            this._GenericRepository.UpdateEntity(owner);
        }

        public void DeleteEntity(int id)
        {
            // Διαγραφή μιας οντότητας τύπου Owner βάσει του Id
            this._GenericRepository.DeleteEntity(id);
        }
    }
}
