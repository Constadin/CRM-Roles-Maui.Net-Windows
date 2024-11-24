
using CRM.Domain.Owners.Interfaces;
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
        private string _FirstName;
        private string _LastName;
        private readonly IOwnerRepositoryGRUD _OwnerRepositoryGRUD;
        
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


        public ICommand LoadDataCommand { get; }
        #endregion

        #region Constructors

        // Constructor that calls LoadData to load owners into the ObservableCollection
        public MainPageViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {
                       
            this._OwnerRepositoryGRUD = serviceProvider.GetRequiredService<IOwnerRepositoryGRUD>();
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
                var ownersList = this._OwnerRepositoryGRUD.LoadOwners();
                this.Owners = new ObservableCollection<Owner>(ownersList); // Assign the loaded owners list to the ObservableCollection
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

