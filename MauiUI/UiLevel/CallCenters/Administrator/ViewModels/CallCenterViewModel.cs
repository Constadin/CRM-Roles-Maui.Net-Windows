
using MauiUI.Helpers.ViewModels;
using MauiUI.UiLevel.CallCenters.Administrator.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MauiUI.UiLevel.CallCenters.Administrator.ViewModels
{
    class CallCenterViewModel : BaseViewModel
    {
        #region Public Fields

        public string _SearchTerm;

        #endregion

        #region Constactors
        public CallCenterViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            AllCalls = new ObservableCollection<CompanyCall>(); // Initialize the collection
            FilteredCalls = new ObservableCollection<CompanyCall>();
            FilterOptions = new List<string>
                            {
                                "Serial Number",
                                "Admin Name",
                                "Company Name",
                                "Specialty",
                                "Phone Number",
                                "Email"
                            };

            LoadSampleData();
        }
        #endregion

        #region Public Properties
        public ObservableCollection<CompanyCall> AllCalls { get; set; }
        public ObservableCollection<CompanyCall> FilteredCalls { get; set; }
        public string? _SelectedFilter;
        private string? _CompanyName;
        private string? _Specialty;
        private string? _PhoneNumber;
        private string? _Email;
        private string? _AdminName;
        private string? _Address;
        private string? _PostalCode;
        private string? _City;
        private string? _Country;
        private string? _SerialNumber;
        public List<string> FilterOptions { get; set; }
        public string SearchTerm
        {
            get => this._SearchTerm;
            set
            {
                this._SearchTerm = value;
                OnPropertyChanged();
                FilterCalls();
            }
        }
        public string? SelectedFilter
        {
            get => this._SelectedFilter;
            set
            {
                if (this.SetPropertyValue(ref this._SelectedFilter, value))
                {
                    FilterCalls(); // Call FilterCalls when the selected filter changes
                }
            }
        }
        public string? CompanyName
        {
            get => this._CompanyName;
            set => this.SetPropertyValue(ref this._CompanyName, value);
        }

        public string? Specialty
        {
            get => this._Specialty;
            set => this.SetPropertyValue(ref this._Specialty, value);
        }

        public string? PhoneNumber
        {
            get => this._PhoneNumber;
            set => this.SetPropertyValue(ref this._PhoneNumber, value);
        }

        public string? Email
        {
            get => this._Email;
            set => this.SetPropertyValue(ref this._Email, value);
        }

        public string? AdminName
        {
            get => this._AdminName;
            set => this.SetPropertyValue(ref this._AdminName, value);
        }

        public string? Address
        {
            get => this._Address;
            set => this.SetPropertyValue(ref this._Address, value);
        }

        public string? PostalCode
        {
            get => this._PostalCode;
            set => this.SetPropertyValue(ref this._PostalCode, value);
        }

        public string? City
        {
            get => this._City;
            set => this.SetPropertyValue(ref this._City, value);
        }

        public string? Country
        {
            get => this._Country;
            set => this.SetPropertyValue(ref this._Country, value);
        }
        public string? SerialNumber
        {
            get => this._SerialNumber;
            set => this.SetPropertyValue(ref this._SerialNumber, value);
        }

        #endregion

        #region Private Method
        private void LoadSampleData()
        {
            // Προσθέστε εδώ κλήσεις για δοκιμή
            AllCalls.Add(new CompanyCall
            {
                CompanyName = "Company A",
                Specialty = "Dentist",
                PhoneNumber = "2108545222",
                Email = "contact@companya.com",
                AdminName = "John Doe",
                Address = "Street 1",
                PostalCode = "10001",
                City = "Athens",
                Country = "Greece",
                SerialNumber = "SN001" // Ensure you populate SerialNumber
            });

            // Προσθέστε περισσότερες κλήσεις όπως χρειάζεται
            this.FilteredCalls = new ObservableCollection<CompanyCall>(AllCalls);
        }
        private void FilterCalls()
        {
            this.FilteredCalls.Clear();

            // Check if SearchTerm is null or empty
            if (string.IsNullOrEmpty(this.SearchTerm))
            {
                // If SearchTerm is empty, display all calls
                foreach (var call in AllCalls)
                {
                    this.FilteredCalls.Add(call);
                }
                return;
            }

            var filtered = AllCalls.Where(c =>
                        this.SelectedFilter == "Serial Number" && c.SerialNumber != null && c.SerialNumber.IndexOf(SearchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        this.SelectedFilter == "Admin Name" && c.AdminName != null && c.AdminName.IndexOf(SearchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        this.SelectedFilter == "Company Name" && c.CompanyName != null && c.CompanyName.IndexOf(SearchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        this.SelectedFilter == "Specialty" && c.Specialty != null && c.Specialty.IndexOf(SearchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        this.SelectedFilter == "Phone Number" && c.PhoneNumber != null && c.PhoneNumber.IndexOf(SearchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        this.SelectedFilter == "Email" && c.Email != null && c.Email.IndexOf(SearchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        this.SelectedFilter == "Address" && c.Address != null && c.Address.IndexOf(SearchTerm, StringComparison.OrdinalIgnoreCase) >= 0);

            foreach (var call in filtered)
            {
                this.FilteredCalls.Add(call);
            }
        }

        #endregion
    }
}
