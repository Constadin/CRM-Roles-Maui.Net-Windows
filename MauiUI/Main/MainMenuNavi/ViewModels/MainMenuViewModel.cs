using CRM.Abstractions.Services;
using CRM.Domain;
using MauiUI.Helpers.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiUI.Main.MainMenuNavi.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        #region Private Fields
        private readonly IRoleService _RoleService;
        private readonly IAuthorizationService _AuthorizationService;

        #endregion

        #region Constractor
        public MainMenuViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this._RoleService = serviceProvider.GetRequiredService<IRoleService>();
            this._AuthorizationService = serviceProvider.GetRequiredService<IAuthorizationService>();

            // Ρύθμιση της αρχικής σελίδας με βάση τον ρόλο            

            this.SetInitialPageAsync();

            this.NavigateCommand = new DelegateCommand<string>(async (pageKey) => await OnNavigateAsync(pageKey));
        }

        #endregion

        #region  Public Properties
        // Εντολή πλοήγησης
        public DelegateCommand<string> NavigateCommand { get; }
        public ObservableCollection<MenuItemViewModel> MenuItemBtnList { get; } = new ObservableCollection<MenuItemViewModel>();

        #endregion

        #region Private Mathods
        private async Task SetInitialPageAsync()
        {
            string? role = this._RoleService.CurrentRole;

            this.MenuItemBtnList.Clear();

            if (role != null)
            {
                if (role == "Administrator")
                {
                    await this.NavigationService.NavigateAsync("NavigationPage/DashboardViewPage");
                }
                else if (role == "Dentist")
                {
                    await this.NavigationService.NavigateAsync("NavigationPage/MainPage");
                }
                else if (role == "Ophthalmologist")
                {
                    await this.NavigationService.NavigateAsync("NavigationPage/CallCenterViewPage");
                }

                foreach (var menuItem in MenuItems.Items)
                {
                    // Ελέγχουμε αν ο χρήστης έχει πρόσβαση
                    if (await this._AuthorizationService.CanAccessPageAsync(role, menuItem.PageKey))
                    {

                        MenuItemBtnList.Add(new MenuItemViewModel()
                        {
                            Title = menuItem.Title,
                            Command = new DelegateCommand(async () => await OnNavigateAsync(menuItem.PageKey))
                        });
                    }
                }

                // Πάντα προστίθεται το κουμπί Log out
                MenuItemBtnList.Add(new MenuItemViewModel()
                {
                    Title = "Log out",
                    Command = new DelegateCommand(async () => await OnNavigateAsync("LoginViewPage"))
                });
            }
        }

        private async Task OnNavigateAsync(string pageKey)
        {
            try
            {
                if (pageKey == "LoginViewPage")
                {
                    await NavigationService.NavigateAsync("LoginViewPage");

                    this._RoleService.ClearRole();
                }
                else
                {
                    await NavigationService.NavigateAsync($"NavigationPage/{pageKey}");
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during navigation: {ex.Message}");
            }
        }

        #endregion
    }
}
