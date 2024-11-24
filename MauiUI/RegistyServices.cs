using CRM.Domain.Owners.Interfaces;
using CRM.Infrastructure.Configuration.Services;
using CRM.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiUI
{
    public static class RegistyServices // Κλάση για την καταχώριση υπηρεσιών.
    {
        public static IServiceCollection RegisterUiServices(this IServiceCollection services) // Μέθοδος για την καταχώριση υπηρεσιών στο IServiceCollection.
        { 
            services.AddSingleton<IDatabaseConnectionProvider, DatabaseConnectionProvider>();
            services.AddSingleton<IOwnerRepositoryGRUD, IOwnerRepositoryGRUD>();

            return services; // Επιστρέφει το IServiceCollection για αλυσίδωτες κλήσεις.
        }

        public static IContainerRegistry RegisterUiServices(this IContainerRegistry containerRegistry) // Μέθοδος για την καταχώριση υπηρεσιών στο IContainerRegistry.
        {           

            containerRegistry.RegisterSingleton<IDatabaseConnectionProvider, DatabaseConnectionProvider>();
            containerRegistry.RegisterSingleton<IOwnerRepositoryGRUD, OwnerRepositoryGRUD>();

            return containerRegistry; // Επιστρέφει το IContainerRegistry για αλυσίδωτες κλήσεις.
        }
    }
}
