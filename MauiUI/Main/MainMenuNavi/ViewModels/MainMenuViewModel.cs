using CRM.Abstractions.Services;
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
        private readonly IRoleService _RoleService;
        public ObservableCollection<MenuItemViewModel> MenuItemBtnList { get; } = new ObservableCollection<MenuItemViewModel>();

        // Κατασκευαστής
        public MainMenuViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this._RoleService = serviceProvider.GetRequiredService<IRoleService>();

            // Ρύθμιση της αρχικής σελίδας με βάση τον ρόλο            

            this.SetInitialPageAsync();

            this.NavigateCommand = new DelegateCommand<string>(async (pageKey) => await OnNavigateAsync(pageKey));
        }

        // Εντολή πλοήγησης
        public DelegateCommand<string> NavigateCommand { get; }

        private async void SetInitialPageAsync()
        {
            string? role = this._RoleService.CurrentRole;

            this.MenuItemBtnList.Clear();


            if (role == "Administrator")
            {
                await this.NavigationService.NavigateAsync("NavigationPage/DashboardViewPage");

                MenuItemBtnList.Add(new MenuItemViewModel()
                {
                    Title = "Call Center",
                    Command = new DelegateCommand(async () => await OnNavigateAsync("CallCenterViewPage"))
                });

                MenuItemBtnList.Add(new MenuItemViewModel()
                {
                    Title = "Companies",
                    Command = new DelegateCommand(async () => await OnNavigateAsync("MainPage"))
                });

                MenuItemBtnList.Add(new MenuItemViewModel
                {
                    Title = "Log out",
                    Command = new DelegateCommand(async () => await OnNavigateAsync("LoginViewPage"))
                });


            }
            else if (role == "dentist")
            {

            }
            else if (role == "ophthalmologist")
            {
                //await this.NavigationService.NavigateAsync("NavigationPage/MainPage");
            }
            else
            {
                //await NavigationService.NavigateAsync("LoginViewPage");
            }
        }

        private async Task OnNavigateAsync(string pageKey)
        {       
            try
            {   
                if(pageKey == "LoginViewPage")
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
    }
}
