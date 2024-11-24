using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Owners.Models
{
    public class Owner
    {
        // Αναγνωριστικό του ιδιοκτήτη (πρωτεύον κλειδί)

        public int Id { get; set; }

        // Όνομα χρήστη για σύνδεση
        [Required]
        [StringLength(30)]
        public string? Username { get; set; }

        // Κωδικός πρόσβασης που αποθηκεύεται κατακερματισμένος
        [Required]
        [StringLength(20)]
        public string? PasswordHash { get; set; }

        // Ξένο κλειδί για τον τύπο καταστήματος
        public int? TypeOfStoreId { get; set; }

        // Ιδιότητα πλοήγησης (συσχέτιση με τον πίνακα TypeOfStores)
        public TypeOfStore? TypeOfStore { get; set; }

        // Υπολογιζόμενη ιδιότητα για το όνομα του τύπου καταστήματος
        public string? TypeOfStoreName => TypeOfStore?.TypeOfStoreName;
    }

}
