using CRM.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        public async Task<string?> AuthenticateAsync(string username, string password)
        {
            // Προσομοίωση βάσης δεδομένων (θα πρέπει να αντικατασταθεί με πραγματική σύνδεση)
            var users = new Dictionary<string, (string Password, string Role)>
            {
                { "admin", ("123", "Administrator") },
                { "user", ("123", "User") }
            };

            // Έλεγχος αν υπάρχει ο χρήστης
            if (users.TryGetValue(username, out var userInfo) && userInfo.Password == password)
            {
                // Επιστροφή του ρόλου

                return userInfo.Role;
            }

            return null; // Αν ο χρήστης δεν βρεθεί ή το password είναι λάθος
        }
    }
}
