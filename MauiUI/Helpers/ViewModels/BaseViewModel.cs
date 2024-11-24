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
        protected readonly IServiceProvider ServiceProvider;
        protected readonly INavigationService NavigationService;

        public BaseViewModel(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
            this.NavigationService = serviceProvider.GetRequiredService<INavigationService>();
        }

        public virtual Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            // Override this method to add logic for conditional navigation
            return Task.FromResult(true);
        }

        public virtual void Destroy()
        {
            // Override to release resources if necessary
        }

        public virtual void OnAppearing()
        {
            // Override to handle logic when page appears
        }

        public virtual void OnDisappearing()
        {
            // Override to handle logic when page disappears
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            // Override to handle logic when navigating away from the page
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            // Override to handle logic when navigating to the page
        }
    }
}
