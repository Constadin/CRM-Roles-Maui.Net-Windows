using MauiUI.Helpers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiUI.Pages.Login.ViewModels
{
    public partial class LoginViewModel : BaseViewModel // Κλάση για το ViewModel της σύνδεσης χρηστών
    {

        #region fields
        private string? _Username; // Ιδιότητα για το όνομα χρήστη.
        private string? _Password; // Ιδιότητα για τον κωδικό πρόσβασης.
       // private readonly IRoleService _RoleService; // Υπηρεσία ρόλων.
       // private readonly ILoginService _LoginService; // Υπηρεσία σύνδεσης.
        public ICommand LoginCommand { get; } // Εντολή για τη σύνδεση χρήστη.
        #endregion

        #region Constractors
        public LoginViewModel(IServiceProvider serviceProvider) : base(serviceProvider) // Κατασκευαστής
        {
            // Ανάκτηση των υπηρεσιών μέσω του service provider.
            //this._LoginService = serviceProvider.GetRequiredService<ILoginService>();
            //this._RoleService = serviceProvider.GetRequiredService<IRoleService>();
            this.LoginCommand = new DelegateCommand(async () => await OnLoginAsync()); // Δημιουργία εντολής σύνδεσης.
        }
        #endregion

        #region Public Properties
        public string? Username // Ιδιότητα για το όνομα χρήστη με ειδοποίηση αλλαγής.
        {
            get => this._Username; // Επιστρέφει το όνομα χρήστη.
            set => SetPropertyValue(ref this._Username, value); // Ρυθμίζει την τιμή και ειδοποιεί για αλλαγές.
        }

        public string? Password // Ιδιότητα για τον κωδικό πρόσβασης με ειδοποίηση αλλαγής.
        {
            get => this._Password; // Επιστρέφει τον κωδικό πρόσβασης.
            set => SetPropertyValue(ref this._Password, value); // Ρυθμίζει την τιμή και ειδοποιεί για αλλαγές.
        }
        #endregion

        #region Private Methods 
        private async Task OnLoginAsync() // Ασύγχρονη μέθοδος για τη διαδικασία σύνδεσης.
        {
            await this._LoginService.AuthenticateAsync(this.Username, this.Password); // Κλήση υπηρεσίας για αυθεντικοποίηση.
            string? role = this._RoleService.CurrentRole; // Ανάκτηση του τρέχοντος ρόλου.

            //Έλεγχος αν ο ρόλος είναι έγκυρος.
            if (!string.IsNullOrEmpty(role))
            {
                await NavigateToInitializer(); // Πλοήγηση στη σελίδα εκκίνησης.
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password", "OK"); // Εμφάνιση μηνύματος σφάλματος.
                //this.Username = null; // Εκκαθάριση του ονόματος χρήστη.
                //this.Password = null; // Εκκαθάριση του κωδικού πρόσβασης.
            }
        }

        private async Task NavigateToInitializer() // Ιδιωτική μέθοδος πλοήγησης στη σελίδα εκκίνησης.
        {
            await this.NavigationService.NavigateAsync("InitializerViewPage"); // Πλοήγηση στην InitializerViewPage.
        }
        #endregion
    }
}
