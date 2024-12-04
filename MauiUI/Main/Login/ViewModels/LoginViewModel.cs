using CRM.Abstractions.Services;
using MauiUI.Helpers.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiUI.Main.Login.ViewModels
{
    public partial class LoginViewModel : BaseViewModel // Κλάση για το ViewModel της σύνδεσης χρηστών
    {

        #region Private fields
        private string? _Username; // Ιδιότητα για το όνομα χρήστη.
        private string? _Password; // Ιδιότητα για τον κωδικό πρόσβασης.
        private readonly IRoleService _RoleService; // Υπηρεσία ρόλων.
        private readonly ILoginService _LoginService; // Υπηρεσία σύνδεσης.
        public ICommand LoginCommand { get; } // Εντολή για τη σύνδεση χρήστη.
        #endregion

        #region Constractors
        public LoginViewModel(IServiceProvider serviceProvider) : base(serviceProvider) // Κατασκευαστής
        {
            // Ανάκτηση των υπηρεσιών μέσω του service provider.
            this._LoginService = serviceProvider.GetRequiredService<ILoginService>();
            this._RoleService = serviceProvider.GetRequiredService<IRoleService>();
            this.LoginCommand = new DelegateCommand(async () => await OnLoginAsync()); // Δημιουργία εντολής σύνδεσης.
        }
        #endregion

        #region Public Properties
        public string? Username // Ιδιότητα για το όνομα χρήστη με ειδοποίηση αλλαγής.
        {
            get => this._Username; // Επιστρέφει το όνομα χρήστη.
            set => this.SetPropertyValue(ref this._Username, value); // Ρυθμίζει την τιμή και ειδοποιεί για αλλαγές.
        }

        public string? Password // Ιδιότητα για τον κωδικό πρόσβασης με ειδοποίηση αλλαγής.
        {
            get => this._Password; // Επιστρέφει τον κωδικό πρόσβασης.
            set => this.SetPropertyValue(ref this._Password, value); // Ρυθμίζει την τιμή και ειδοποιεί για αλλαγές.
        }
        #endregion

        #region Private Methods 
        private async Task OnLoginAsync() // Ασύγχρονη μέθοδος για τη διαδικασία σύνδεσης.
        {
            var role = await this._RoleService.SetRoleAsync(await this._LoginService.LoginAsync(Username, Password));
            // Κλήση υπηρεσίας LoginService για αυθεντικοποίηση => return Role

            //Έλεγχος αν ο ρόλος είναι έγκυρος.
            if (!string.IsNullOrEmpty(role))
            {
                await NavigateToInitializer(role); // Πλοήγηση στη σελίδα εκκίνησης.
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password", "OK"); // Εμφάνιση μηνύματος σφάλματος.

            }
        }

        private async Task NavigateToInitializer(string role) // Ιδιωτική μέθοδος πλοήγησης στη σελίδα εκκίνησης.
        {
            await NavigationService.NavigateAsync($"InitializerViewPage?role={role}"); // Πλοήγηση στην InitializerViewPage.
        }
        #endregion
    }
}
