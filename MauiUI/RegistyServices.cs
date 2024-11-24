using CRM.Abstractions.Interfaces;
using CRM.Domain.Owners.Models;
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
            services.AddSingleton<IRepositoryGRUD<Owner>, OwnerRepositoryGRUD>();
            return services; // Επιστρέφει το IServiceCollection για αλυσίδωτες κλήσεις.
        }

        public static IContainerRegistry RegisterUiServices(this IContainerRegistry containerRegistry) // Μέθοδος για την καταχώριση υπηρεσιών στο IContainerRegistry.
        {           

            containerRegistry.RegisterSingleton<IDatabaseConnectionProvider, DatabaseConnectionProvider>();
            containerRegistry.RegisterSingleton<IRepositoryGRUD<Owner>, OwnerRepositoryGRUD>();

            return containerRegistry; // Επιστρέφει το IContainerRegistry για αλυσίδωτες κλήσεις.
        }
    }
}
