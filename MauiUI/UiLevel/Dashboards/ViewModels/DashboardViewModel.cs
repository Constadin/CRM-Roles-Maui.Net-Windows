using CRM.Abstractions.Services;
using Example;
using MauiAppPrismApp.Classes;
using MauiUI.Helpers.ViewModels;
using MauiUI.UiLevel.Dashboards.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiUI.UiLevel.Dashboards.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        #region Private Fields
        // Property to hold the user dashboard view content
        private ContentView _UserDashboardView;
        private readonly IRoleService _RoleService;
        private readonly IDateTimeService _DateTimeService;
        private string _CurrentDateTime;

        #endregion

        #region Public Fields        
        public string? _ColorOfService;
        public string? _NameOfService;
        public string? _IsEnableService;
        public Command? _GoToService;
        #endregion

        #region Constractors
        public DashboardViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this._RoleService = serviceProvider.GetRequiredService<IRoleService>();
            this._UserDashboardView = new ContentView();
            this._DateTimeService = serviceProvider.GetRequiredService<IDateTimeService>();
            this.MicroServicesList = new ObservableCollection<MicroServices>();     
            this.LoadServices(); // Call the method to load services
            this.LoadUserDashboard();
        }

        #endregion

        #region Public Properties
        public ObservableCollection<MicroServices> MicroServicesList { get; set; }
        public ContentView UserDashboardView
        {
            get => _UserDashboardView;
            set => SetPropertyValue(ref _UserDashboardView, value);
        }

        public string? ColorOfService
        {
            get => _ColorOfService;
            set => SetPropertyValue(ref _ColorOfService, value);
        }

        public string? NameOfService
        {
            get => _NameOfService;
            set => SetPropertyValue(ref _NameOfService, value);
        }

        public string? IsEnableService
        {
            get => _IsEnableService;
            set => SetPropertyValue(ref _IsEnableService, value);
        }
        public Command? GoToService
        {
            get => _GoToService;
            set => SetPropertyValue(ref _GoToService, value);
        }

        public string CurrentDateTime
        {
            get => _DateTimeService.GetCurrentDate().ToString("dd/MM/yyyy");
        }
        #endregion

        #region Private Method


        private void LoadUserDashboard()
        {

            // Assign the appropriate dashboard view based on role
            UserDashboardView = _RoleService.CurrentRole switch
            {
                "Administrator" => new DashboardAdminView(),

                _ => new ContentView() // Default or error handling
            };
        }

        private async void LoadServices()
        {
            // Simulate fetching data from a database or API
            var servicesList = await FetchServicesAsync(); // This should be your method to fetch services
            foreach (var service in servicesList)
            {
                service.GoToService = new Command(() => NavigateToService(service.NameOfService));
                MicroServicesList.Add(service);
            }
        }

        private async void NavigateToService(string serviceName)
        {
            string message = $"You selected the {serviceName} service.";
            // Navigation logic based on the service name
            switch (serviceName)
            {
                case "User Management":
                    // Navigate to User Management page
                    await Application.Current.MainPage.DisplayAlert("Service Selected", message, "OK");
                    break;
                case "Payment Processing":
                    // Navigate to Payment Processing page
                    await Application.Current.MainPage.DisplayAlert("Service Selected", message, "OK");
                    break;
                case "Data Analytics":
                    // Navigate to Data Analytics page
                    await Application.Current.MainPage.DisplayAlert("Service Selected", message, "OK");
                    break;
                case "Notification Service":
                    // Navigate to Notification Service page
                    await Application.Current.MainPage.DisplayAlert("Service Selected", message, "OK");
                    break;
                case "Reporting Service":
                    // Navigate to Reporting Service page
                    await Application.Current.MainPage.DisplayAlert("Service Selected", message, "OK");
                    break;
                case "Processing":
                    // Navigate to Payment Processing page
                    await Application.Current.MainPage.DisplayAlert("Service Selected", message, "OK");
                    break;
                case "Analytics":
                    // Navigate to Data Analytics page
                    await Application.Current.MainPage.DisplayAlert("Service Selected", message, "OK");
                    break;
                case "Notification":
                    // Navigate to Notification Service page
                    await Application.Current.MainPage.DisplayAlert("Service Selected", message, "OK");
                    break;
                case " Service":
                    // Navigate to Reporting Service page
                    await Application.Current.MainPage.DisplayAlert("Service Selected", message, "OK");
                    break;
            }
        }
        private Task<List<MicroServices>> FetchServicesAsync()
        {
            // Replace this with your actual data fetching logic
            return Task.FromResult(new List<MicroServices>
        {
            new MicroServices { NameOfService = "User Management", ColorOfService = "LightBlue", IsEnableService = "Enable" },
            new MicroServices { NameOfService = "Payment Processing", ColorOfService = "LightGreen", IsEnableService = "Enable" },
            new MicroServices { NameOfService = "Data Analytics", ColorOfService = "LightCoral", IsEnableService = "Enable" },
            new MicroServices { NameOfService = "Notification Service", ColorOfService = "LightGoldenrodYellow", IsEnableService = "Enable" },
            new MicroServices { NameOfService = "Reporting Service", ColorOfService = "LightSalmon", IsEnableService = "Enable" },

            new MicroServices { NameOfService = "Processing", ColorOfService = "LightGreen", IsEnableService = "Enable" },
            new MicroServices { NameOfService = "Analytics", ColorOfService = "LightCoral", IsEnableService = "Enable" },
            new MicroServices { NameOfService = "Notification", ColorOfService = "LightGoldenrodYellow", IsEnableService = "Enable" },
            new MicroServices { NameOfService = "Service", ColorOfService = "LightSalmon", IsEnableService = "Enable" },

        });
        }
        #endregion
    }
}
