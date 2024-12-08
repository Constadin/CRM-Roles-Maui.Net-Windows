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

        #region Constructors
        public DashboardViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this._RoleService = serviceProvider.GetRequiredService<IRoleService>();
            this._UserDashboardView = new ContentView();
            this._DateTimeService = serviceProvider.GetRequiredService<IDateTimeService>();
            this.MicroServicesList = new ObservableCollection<MicroServices>();
            this.LoadServices(); // Κλήση για φόρτωση υπηρεσιών
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

        #region Private Methods

        /// <summary>
        /// Φορτώνει το dashboard του χρήστη με βάση το ρόλο.
        /// </summary>
        private void LoadUserDashboard()
        {
            UserDashboardView = _RoleService.CurrentRole switch
            {
                "Administrator" => new DashboardAdminView(),
                _ => new ContentView()
            };
        }

        /// <summary>
        /// Φορτώνει τις υπηρεσίες από μια βάση δεδομένων ή API.
        /// </summary>
        private async void LoadServices()
        {
            var servicesList = await FetchServicesAsync();
            foreach (var service in servicesList)
            {
                service.GoToService = new Command(() => NavigateToService(service.NameOfService));
                MicroServicesList.Add(service);
            }
        }

        /// <summary>
        /// Πλοήγηση σε υπηρεσία όταν ο χρήστης επιλέξει μία.
        /// </summary>
        private async void NavigateToService(string serviceName)
        {
            string message = $"You selected the {serviceName} service.";

            switch (serviceName)
            {
                case "User Management":
                case "Payment Processing":
                case "Data Analytics":
                case "Notification Service":
                case "Reporting Service":
                case "Processing":
                case "Analytics":
                case "Notification":
                case "Service":
                    await Application.Current.MainPage.DisplayAlert("Service Selected", message, "OK");
                    break;
                default:
                    await Application.Current.MainPage.DisplayAlert("Service Selected", "Service not available.", "OK");
                    break;
            }
        }

        /// <summary>
        /// Φαίνεται ότι γίνεται ανάκτηση των δεδομένων υπηρεσιών (simulation με async).
        /// </summary>
        private Task<List<MicroServices>> FetchServicesAsync()
        {
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
