using CRM.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Services
{
    public class LoginService : ILoginService
    {
        private readonly IAuthenticateService _AuthenticateService;

        public LoginService(IAuthenticateService authenticateService)
        {
            // Αρχικοποίηση της υπηρεσίας αυθεντικοποίησης
            this._AuthenticateService = authenticateService;
        }

        public async Task<string?> LoginAsync(string username, string password)
        {
            // Κλήση της υπηρεσίας αυθεντικοποίησης για έλεγχο των διαπιστευτηρίων
            return await this._AuthenticateService.AuthenticateAsync(username, password);
        }
    }
}
