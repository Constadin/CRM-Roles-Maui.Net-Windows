using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Διεπαφή που ορίζει τη λειτουργικότητα της υπηρεσίας ρόλων.
/// </summary>
namespace CRM.Abstractions.Services
{
    /// <summary>
    /// Παρέχει μεθόδους για τη διαχείριση του ρόλου του χρήστη.
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// Ιδιότητα που αναπαριστά τον τρέχοντα ρόλο του χρήστη.
        /// </summary>
        string? CurrentRole { get; set; }

        /// <summary>
        /// Ορίζει τον ρόλο του χρήστη.
        /// </summary>
        /// <param name="role">Ο ρόλος που πρέπει να οριστεί για τον χρήστη.</param>
        /// <returns>Μια εργασία που αναπαριστά τη ασύγχρονη λειτουργία. 
        /// Το αποτέλεσμα της εργασίας είναι ένα string που αναπαριστά την επιτυχία της διαδικασίας ορισμού του ρόλου.</returns>
        Task<string> SetRoleAsync(string role);

        /// <summary>
        /// Καθαρίζει τον τρέχοντα ρόλο του χρήστη.
        /// </summary>
        void ClearRole();
    }
}

