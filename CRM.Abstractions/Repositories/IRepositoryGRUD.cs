using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Abstractions.Repositories
{
    public interface IRepositoryGRUD<T> where T : class
    {
        /// <summary>
        /// Φορτώνει μια λίστα με όλες τις οντότητες τύπου T από τη βάση δεδομένων.
        /// Αυτή η μέθοδος ανακτά όλες τις εγγραφές τύπου T από τον αντίστοιχο πίνακα.
        /// </summary>
        /// <returns>Μια λίστα οντοτήτων τύπου T.</returns>
        List<T> LoadEntities();

        /// <summary>
        /// Αποθηκεύει μια νέα οντότητα τύπου T στη βάση δεδομένων.
        /// Αυτή η μέθοδος εισάγει την παρεχόμενη οντότητα στον αντίστοιχο πίνακα.
        /// </summary>
        /// <param name="entity">Η οντότητα τύπου T που θα αποθηκευτεί.</param>
        void SaveEntity(T entity);

        /// <summary>
        /// Ενημερώνει μια υπάρχουσα οντότητα τύπου T στη βάση δεδομένων.
        /// Αυτή η μέθοδος τροποποιεί τις τιμές μιας οντότητας στη βάση δεδομένων βάσει της παρεχόμενης οντότητας.
        /// Υποθέτει ότι η οντότητα περιέχει έναν ταυτοποιητή (π.χ. Id) για τον εντοπισμό της υπάρχουσας εγγραφής.
        /// </summary>
        /// <param name="entity">Η οντότητα τύπου T που θα ενημερωθεί.</param>
        void UpdateEntity(T entity);

        /// <summary>
        /// Διαγράφει μια οντότητα τύπου T από τη βάση δεδομένων βάσει του Id της.
        /// Αυτή η μέθοδος αφαιρεί την εγγραφή που αντιστοιχεί στο παρεχόμενο Id από τον αντίστοιχο πίνακα.
        /// </summary>
        /// <param name="id">Ο ταυτοποιητής (Id) της οντότητας που θα διαγραφεί.</param>
        void DeleteEntity(int id);
    }
}
