using CRM.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Services
{
    public class RoleService : IRoleService
    {
       public string? CurrentRole { get; set; }

        // Ιδιωτικός κατασκευαστής για να αποτρέψετε την άμεση δημιουργία
        
        public async Task<string> SetRoleAsync(string role)
        {
            // Εδώ μπορείς να προσθέσεις οποιαδήποτε λογική αν χρειάζεσαι (π.χ., αποθήκευση σε αποθήκη, API κλπ)
            this.CurrentRole = role; // Αποθηκεύουμε τον ρόλο
            return await Task.FromResult(CurrentRole); // Επιστρέφουμε τον ρόλο
        }

        public void ClearRole()
        {
            this.CurrentRole = null; // Επαναφορά του ρόλου
        }
    }
}
