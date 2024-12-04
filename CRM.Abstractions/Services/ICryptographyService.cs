using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Διεπαφή που ορίζει τη λειτουργικότητα της υπηρεσίας κρυπτογράφησης.
/// </summary>
namespace CRM.Abstractions.Services
{
    /// <summary>
    /// Παρέχει μεθόδους για τη κρυπτογράφηση και την επαλήθευση κωδικών πρόσβασης.
    /// </summary>
    public interface ICryptographyService
    {
        /// <summary>
        /// Κρυπτογραφεί τον κωδικό πρόσβασης.
        /// </summary>
        /// <param name="password">Ο κωδικός πρόσβασης που πρέπει να κρυπτογραφηθεί.</param>
        /// <returns>Ο κρυπτογραφημένος κωδικός πρόσβασης.</returns>
        string HashPassword(string password);

        /// <summary>
        /// Επαληθεύει τον κωδικό πρόσβασης συγκρίνοντάς τον με το αποθηκευμένο κρυπτογραφημένο hash.
        /// </summary>
        /// <param name="password">Ο κωδικός πρόσβασης που πρέπει να επαληθευτεί.</param>
        /// <param name="storedHash">Ο αποθηκευμένος κρυπτογραφημένος κωδικός πρόσβασης.</param>
        /// <returns>Αληθές αν ο κωδικός πρόσβασης αντιστοιχεί στο αποθηκευμένο hash, αλλιώς ψευδές.</returns>
        bool VerifyPassword(string password, string storedHash);
    }
}

