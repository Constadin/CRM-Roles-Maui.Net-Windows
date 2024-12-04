using CRM.Abstractions.Repositories;
using CRM.Domain.Owners.Models;
using CRM.Infrastructure.Configuration.Services;
using CRM.Infrastructure.Repositories;
using MauiUI.Helpers.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace MauiUI
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Private Fields

        // ObservableCollection to hold the owners list
        private ObservableCollection<Owner> _Owner = new ObservableCollection<Owner>();
        private readonly IRepositoryGRUD<Owner> _OwnerRepository; // Injected repository
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _PhoneNumber;
        private string _VatNumber;
        private int _TypeOfStoreID;

        #endregion

        #region Public Properties

        public ObservableCollection<Owner> Owners
        {
            get => this._Owner;
            set => this.SetPropertyValue(ref this._Owner, value); // Ensure SetPropertyValue correctly triggers OnPropertyChanged
        }
        public string FirstName
        {
            get => this._FirstName;
            set => this.SetPropertyValue(ref this._FirstName, value); // Ensure SetPropertyValue correctly triggers OnPropertyChanged
        }
        public string LastName
        {
            get => this._LastName;
            set => this.SetPropertyValue(ref this._LastName, value); // Ensure SetPropertyValue correctly triggers OnPropertyChanged
        }
        public string Email
        {
            get => this._Email;
            set => this.SetPropertyValue(ref this._Email, value); // Ensure SetPropertyValue correctly triggers OnPropertyChanged
        }

        public string PhoneNumber
        {
            get => this._PhoneNumber;
            set => this.SetPropertyValue(ref this._PhoneNumber, value); // Ensure SetPropertyValue correctly triggers OnPropertyChanged
        }

        public string VatNumber
        {
            get => this._VatNumber;
            set => this.SetPropertyValue(ref this._VatNumber, value); // Ensure SetPropertyValue correctly triggers OnPropertyChanged
        }
        public int TypeOfStoreID
        {
            get => this._TypeOfStoreID;
            set => this.SetPropertyValue(ref this._TypeOfStoreID, value); // Ensure SetPropertyValue correctly triggers OnPropertyChanged
        }

        public ICommand LoadDataCommand { get; }
        public ICommand SaveOwnerCommand { get; }
        #endregion

        #region Constructors

        // Constructor that calls LoadData to load owners into the ObservableCollection
        public MainPageViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {

            this._OwnerRepository = serviceProvider.GetRequiredService<IRepositoryGRUD<Owner>>();
         
            
            this.SaveOwnerCommand = new Command(async () => await SaveOwnerAsync());

            _ = this.LoadDataAsync();

        }

        #endregion

        #region Private Methods
        // Loads data from the database into the Owners property
        private async Task LoadDataAsync()
        {
            try
            {
                // Simulate async operation (if your repository supports async, make this awaitable)
                await Task.Run(() =>
                {
                    var ownersList = this._OwnerRepository.LoadEntities(); // Load owners
                    this.Owners = new ObservableCollection<Owner>(ownersList); // Assign to the ObservableCollection
                });
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., logging
                System.Diagnostics.Debug.WriteLine($"Error loading owners: {ex.Message}");
            }
        }

        public async Task SaveOwnerAsync()
        {
           
            try  
            {
                var ownerAdd = new Owner
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    Email = this.Email,
                    VatNumber = this.VatNumber,
                    PhoneNumber = this.PhoneNumber,
                    TypeOfStoreId = this.TypeOfStoreID,
                };


                // Simulate async operation or use an async SaveEntity method if available
                await Task.Run(() =>
                {
                    // Save the owner using the repository
                    this._OwnerRepository.SaveEntity(ownerAdd);
                });
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., logging
                System.Diagnostics.Debug.WriteLine($"Error saving owner: {ex.Message}");
            }
        }

    }
    #endregion
}


