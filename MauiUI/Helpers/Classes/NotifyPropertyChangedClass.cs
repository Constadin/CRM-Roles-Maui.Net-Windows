using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiUI.Helpers.Classes
{
    public class NotifyPropertyChangedClass : INotifyPropertyChanged
    {
        // Επεξεργασία του event για ειδοποίηση αλλαγής ιδιοτήτων
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Μέθοδος για ασφαλή ενημέρωση των ιδιοτήτων με ειδοποίηση αλλαγής
        /// </summary>
        /// <typeparam name="T">Ο τύπος της ιδιοκτησίας</typeparam>
        /// <param name="propertyStore">Η αποθηκευμένη τιμή της ιδιοκτησίας</param>
        /// <param name="value">Η νέα τιμή της ιδιοκτησίας</param>
        /// <param name="propertyName">Το όνομα της ιδιοκτησίας (λαμβάνεται αυτόματα)</param>
        /// <param name="onChanged">Προαιρετική δράση που εκτελείται κατά την αλλαγή</param>
        /// <returns>Αληθές αν η τιμή αλλάχθηκε</returns>
        protected bool SetPropertyValue<T>(ref T propertyStore, T value, [CallerMemberName] string? propertyName = null, Action? onChanged = null)
        {
            if (!EqualityComparer<T>.Default.Equals(propertyStore, value))
            {
                propertyStore = value; // Ενημέρωση της ιδιοκτησίας
                onChanged?.Invoke(); // Εκτέλεση της προαιρετικής δράσης
                this.OnPropertyChanged(propertyName); // Ειδοποίηση της αλλαγής
                return true;
            }
            return false;
        }

        /// <summary>
        /// Μέθοδος για ειδοποίηση ότι μία ιδιοκτησία έχει αλλάξει
        /// </summary>
        /// <param name="propertyName">Το όνομα της ιδιοκτησίας που άλλαξε</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
