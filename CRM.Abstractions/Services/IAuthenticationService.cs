using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Διεπαφή που ορίζει τη λειτουργικότητα της υπηρεσίας αυθεντικοποίησης.
/// </summary>
namespace CRM.Abstractions.Services
{
    /// <summary>
    /// Παρέχει μια μέθοδο για την αυθεντικοποίηση ενός χρήστη.
    /// </summary>
    public interface IAuthenticateService
    {
        /// <summary>
        /// Αυθεντικοποιεί έναν χρήστη με το όνομα χρήστη και τον κωδικό πρόσβασης που παρέχονται.
        /// </summary>
        /// <param name="username">Το όνομα χρήστη του χρήστη που προσπαθεί να αυθεντικοποιηθεί.</param>
        /// <param name="password">Ο κωδικός πρόσβασης του χρήστη που προσπαθεί να αυθεντικοποιηθεί.</param>
        /// <returns>Μια εργασία που αναπαριστά τη ασύγχρονη λειτουργία. 
        /// Το αποτέλεσμα της εργασίας είναι ένα string που αναπαριστά το διακριτικό αυθεντικοποίησης ή null αν αποτύχει η αυθεντικοποίηση.</returns>
        Task<string?> AuthenticateAsync(string username, string password);
    }
}


