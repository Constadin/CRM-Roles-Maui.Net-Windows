using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Abstractions.Services
{
    /// <summary>
    /// Διασύνδεση που καθορίζει την υπηρεσία ελέγχου εξουσιοδότησης.
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// Ελέγχει αν ο χρήστης μπορεί να έχει πρόσβαση σε μία σελίδα με βάση τον ρόλο και το pageKey.
        /// </summary>
        /// <param name="role">Ο ρόλος του χρήστη.</param>
        /// <param name="pageKey">Το μοναδικό αναγνωριστικό της σελίδας.</param>
        /// <returns>Αναφορά που επιστρέφει true αν ο χρήστης έχει πρόσβαση, αλλιώς false.</returns>
        Task<bool> CanAccessPageAsync(string role, string pageKey);
    }
}

