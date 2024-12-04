using CRM.Abstractions.Repositories;
using CRM.Abstractions.Services;
using CRM.Domain.Owners.Models;
using CRM.Infrastructure.Configuration.Services;
using CRM.Infrastructure.Repositories;
using CRM.Infrastructure.Services;
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
            services.AddSingleton<IAuthenticateService, AuthenticateService>();
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<IRoleService, RoleService>();
            services.AddSingleton<IDateTimeService, DateTimeService>();
            return services; // Επιστρέφει το IServiceCollection για αλυσίδωτες κλήσεις.
        }

        public static IContainerRegistry RegisterUiServices(this IContainerRegistry containerRegistry) // Μέθοδος για την καταχώριση υπηρεσιών στο IContainerRegistry.
        {           

            containerRegistry.RegisterSingleton<IDatabaseConnectionProvider, DatabaseConnectionProvider>();
            containerRegistry.RegisterSingleton<IRepositoryGRUD<Owner>, OwnerRepositoryGRUD>();
            containerRegistry.RegisterSingleton<IAuthenticateService, AuthenticateService>();
            containerRegistry.RegisterSingleton<ILoginService, LoginService>();
            containerRegistry.RegisterSingleton<IRoleService, RoleService>();
            containerRegistry.RegisterSingleton<IDateTimeService, DateTimeService>();

            return containerRegistry; // Επιστρέφει το IContainerRegistry για αλυσίδωτες κλήσεις.
        }
    }
}
