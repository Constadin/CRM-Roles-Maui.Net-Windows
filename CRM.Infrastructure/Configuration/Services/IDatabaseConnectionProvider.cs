using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Configuration.Services
{
    public interface IDatabaseConnectionProvider
    {
        /// <summary>
        /// Επιστρέφει την (connection string) για τη βάση δεδομένων.
        /// </summary>
        /// <returns>Η (connection string) για τη βάση δεδομένων.</returns>
        string GetConnectionString();
    }

}
