using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Διεπαφή που ορίζει τη λειτουργικότητα της υπηρεσίας εισόδου.
/// </summary>
namespace CRM.Abstractions.Services
{
    /// <summary>
    /// Παρέχει μια μέθοδο για την είσοδο ενός χρήστη με το όνομα χρήστη και τον κωδικό πρόσβασης.
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Συνδέει έναν χρήστη με το όνομα χρήστη και τον κωδικό πρόσβασης που παρέχονται.
        /// </summary>
        /// <param name="username">Το όνομα χρήστη του χρήστη που προσπαθεί να συνδεθεί.</param>
        /// <param name="password">Ο κωδικός πρόσβασης του χρήστη που προσπαθεί να συνδεθεί.</param>
        /// <returns>Μια εργασία που αναπαριστά τη ασύγχρονη λειτουργία.
        /// Το αποτέλεσμα της εργασίας είναι ένα string που αναπαριστά το διακριτικό σύνδεσης του χρήστη.</returns>
        Task<string> LoginAsync(string username, string password);
    }
}

