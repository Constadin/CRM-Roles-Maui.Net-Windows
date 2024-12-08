
using CRM.Abstractions.Services;
using MauiUI.Helpers.ViewModels;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiUI.Main.Initializer.ViewModels
{
    public class InitializerViewModel : BaseViewModel // Κλάση για το ViewModel εκκίνησης
    {

        #region Private Fields

        private bool _IsBusy; // Ιδιότητα για την κατάσταση απασχόλησης
        private string _StatusMessage; // Ιδιότητα για το μήνυμα κατάστασης
        private readonly IRoleService _RoleService; // Υπηρεσία ρόλων
        #endregion

        #region Public Properties
        public bool IsBusy // Ιδιότητα για την κατάσταση απασχόλησης με ειδοποίηση αλλαγής
        {
            get => this._IsBusy; // Επιστρέφει την κατάσταση απασχόλησης
            set => this.SetPropertyValue(ref this._IsBusy, value); // Ρυθμίζει την κατάσταση και ειδοποιεί για αλλαγές
        }

        public string StatusMessage // Ιδιότητα για το μήνυμα κατάστασης με ειδοποίηση αλλαγής
        {
            get => this._StatusMessage; // Επιστρέφει το μήνυμα κατάστασης
            set => this.SetPropertyValue(ref this._StatusMessage, value); // Ρυθμίζει την τιμή και ειδοποιεί για αλλαγές
        }

        public InitializerViewModel(IServiceProvider serviceProvider) : base(serviceProvider) // Κατασκευαστής
        {
            this.StatusMessage = "Initializing Application..."; // Αρχικοποίηση του μηνύματος κατάστασης
            this.IsBusy = true; // Θέτει την κατάσταση ως απασχολημένη
            this._RoleService = serviceProvider.GetRequiredService<IRoleService>(); // Ανάκτηση της υπηρεσίας ρόλων
            _ = InitializeApplicationAsync(); // Εκκίνηση της διαδικασίας εκκίνησης της εφαρμογής
        }

        #endregion

        #region Handlers
        // Event για την ειδοποίηση ολοκλήρωσης εκκίνησης
        //public event EventHandler InitializationCompleted;

        #endregion

        #region Private methods
        private async Task InitializeApplicationAsync() // Ασύγχρονη μέθοδος εκκίνησης
        {
            try
            {
                // Ανάκτηση του τρέχοντος ρόλου χρήστη
                string? role = this._RoleService.CurrentRole;

                // Ρύθμιση του μηνύματος κατάστασης βάσει του ρόλου
                switch (role)
                {
                    case "Administrator":
                        this.StatusMessage = "Configuring settings for the Administrator...\n"; // Μήνυμα για τον διαχειριστή
                        break;

                    case "Dentist":
                        this.StatusMessage = "Configuring settings for the Dentist...\n"; // Μήνυμα για τον οδοντίατρο
                        break;

                    case "Ophthalmologist":
                        this.StatusMessage = "Configuring settings for the Ophthalmologist...\n"; // Μήνυμα για τον οφθαλμίατρο
                        break;

                    case "Cardiologist":
                        this.StatusMessage = "Configuring settings for the Cardiologist...\n"; 
                        break;

                    case "Βarber":
                        this.StatusMessage = "Configuring settings for the Βarber...\n";
                        break;

                    default:
                        this.StatusMessage = "Role not recognized, returning to login.\n"; // Μήνυμα για μη αναγνωρισμένο ρόλο
                        await Task.Delay(4000); // Προσομοίωση κάποιου χρόνου εργασίας εκκίνησης

                        await NavigateToLoginPage(); // Πλοήγηση στη σελίδα σύνδεσης
                        return; // Έξοδος αν ο ρόλος δεν αναγνωρίζεται
                }

                // Προσομοίωση διαδικασίας εκκίνησης (αντικαταστήστε με την πραγματική λογική)
                await Task.Delay(4000); // Προσομοίωση κάποιου χρόνου εργασίας εκκίνησης

                this.StatusMessage = "Initialization complete! You are now being redirected."; // Μήνυμα ολοκλήρωσης εκκίνησης
            }
            catch (Exception ex) // Επεξεργασία άλλων εξαιρέσεων
            {
                this.StatusMessage = $"Initialization failed: {ex.Message}. Returning to login."; // Μήνυμα σφάλματος εκκίνησης
                await Task.Delay(4000); // Προσομοίωση κάποιου χρόνου εργασίας εκκίνησης

                await NavigateToLoginPage(); // Πλοήγηση στη σελίδα σύνδεσης
                return; // Έξοδος αν υπάρχει σφάλμα
            }
            finally
            {
                this.IsBusy = false; // Θέτει την κατάσταση ως μη απασχολημένη
                //InitializationCompleted?.Invoke(this, EventArgs.Empty); // Ειδοποίηση ολοκλήρωσης εκκίνησης
            }
            await Task.Delay(2000); // Προσομοίωση καθυστέρησης πριν την πλοήγηση
            // Πλοήγηση στη MainHubView μετά από επιτυχημένη εκκίνηση
            await NavigationService.NavigateAsync("MainMenuHubView");
        }

        // Μέθοδος για πλοήγηση στη σελίδα σύνδεσης
        private async Task NavigateToLoginPage()
        {
            await NavigationService.NavigateAsync("LoginViewPage"); // Πλοήγηση στη LoginViewPage
        }

        #endregion
    }
}
