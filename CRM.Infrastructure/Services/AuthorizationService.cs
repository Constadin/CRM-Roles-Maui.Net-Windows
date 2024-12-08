using CRM.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public async Task<bool> CanAccessPageAsync(string role, string pageKey)
        {
            if (role == "Administrator")
            {
                return pageKey == "DashboardViewPage" || pageKey == "MainPage" || pageKey == "CallCenterViewPage";
            }
            else if (role == "Dentist")
            {
                return pageKey == "DashboardViewPage" || pageKey == "CallCenterViewPage";
            }
            else if (role == "Ophthalmologist")
            {
                return pageKey == "DashboardViewPage" || pageKey == "MainPage";
            }



            return false; // Αποτρέπει την πρόσβαση αν ο ρόλος δεν συμφωνεί.
        }
    }
}
