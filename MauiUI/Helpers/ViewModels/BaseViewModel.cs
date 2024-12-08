using MauiUI.Helpers.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiUI.Helpers.ViewModels
{
    public class BaseViewModel : NotifyPropertyChangedClass, IPageLifecycleAware, IDestructible, INavigationAware, IConfirmNavigationAsync
    {
        // Παροχή υπηρεσιών μέσω Dependency Injection
        protected readonly IServiceProvider ServiceProvider;
        protected readonly INavigationService NavigationService;

        public BaseViewModel(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
            this.NavigationService = serviceProvider.GetRequiredService<INavigationService>();
        }

        // Μέθοδος για έλεγχο αν μπορεί να πραγματοποιηθεί πλοήγηση
        public virtual Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            // Υπερκαλύψτε αυτή τη μέθοδο για να προσθέσετε λογική για συνθήκες πλοήγησης
            return Task.FromResult(true);
        }

        // Μέθοδος για απελευθέρωση πόρων
        public virtual void Destroy()
        {
            // Υπερκαλύψτε για να απελευθερώσετε πόρους αν είναι απαραίτητο
        }

        // Μέθοδος που καλείται όταν η σελίδα εμφανίζεται
        public virtual void OnAppearing()
        {
            // Υπερκαλύψτε για να χειριστείτε λογική κατά την εμφάνιση της σελίδας
        }

        // Μέθοδος που καλείται όταν η σελίδα εξαφανίζεται
        public virtual void OnDisappearing()
        {
            // Υπερκαλύψτε για να χειριστείτε λογική κατά την εξαφάνιση της σελίδας
        }

        // Μέθοδος που καλείται όταν η πλοήγηση απομακρύνεται από τη σελίδα
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            // Υπερκαλύψτε για να χειριστείτε λογική κατά την απομάκρυνση από τη σελίδα
        }

        // Μέθοδος που καλείται όταν η πλοήγηση πηγαίνει στη σελίδα
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            // Υπερκαλύψτε για να χειριστείτε λογική κατά την πλοήγηση στη σελίδα
        }
    }
}
