
using CRM.Abstractions.Interfaces;
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
        
        #endregion

        #region Public Properties

        public ObservableCollection<Owner> Owners
        {
            get => this._Owner;
            set => SetPropertyValue(ref this._Owner, value); // Ensure SetPropertyValue correctly triggers OnPropertyChanged
        }
        public string FirstName
        {
            get => _FirstName;
            set => SetPropertyValue(ref _FirstName, value); // Ensure SetPropertyValue correctly triggers OnPropertyChanged
        }
        public string LastName
        {
            get => _LastName;
            set => SetPropertyValue(ref _LastName, value); // Ensure SetPropertyValue correctly triggers OnPropertyChanged
        }
        public string Email
        {
            get => _Email;
            set => SetPropertyValue(ref _Email, value); // Ensure SetPropertyValue correctly triggers OnPropertyChanged
        }

        public string PhoneNumber
        {
            get => _PhoneNumber;
            set => SetPropertyValue(ref _PhoneNumber, value); // Ensure SetPropertyValue correctly triggers OnPropertyChanged
        }

        public string VatNumber
        {
            get => _VatNumber;
            set => SetPropertyValue(ref _VatNumber, value); // Ensure SetPropertyValue correctly triggers OnPropertyChanged
        }



        public ICommand LoadDataCommand { get; }
        #endregion

        #region Constructors

        // Constructor that calls LoadData to load owners into the ObservableCollection
        public MainPageViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {
                       
            this._OwnerRepository = serviceProvider.GetRequiredService<IRepositoryGRUD<Owner>>();
            // Δημιουργία της εντολής Command με την μέθοδο LoadDataAsync
            this.LoadDataCommand = new Command(async () => await LoadDataAsync());

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
                    Owners = new ObservableCollection<Owner>(ownersList); // Assign to the ObservableCollection
                });
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., logging
                System.Diagnostics.Debug.WriteLine($"Error loading owners: {ex.Message}");
            }
        }

        #endregion
    }

}

