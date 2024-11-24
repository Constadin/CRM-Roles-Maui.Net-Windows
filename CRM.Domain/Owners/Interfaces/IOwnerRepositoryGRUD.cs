using CRM.Domain.Owners.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Owners.Interfaces
{
    public interface IOwnerRepositoryGRUD
    {
        List<Owner> LoadOwners();
        void SaveOwner(Owner owner);
    }
}
