using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Abstractions.Services
{
    public interface IDateTimeService
    {
        /// <summary>
        /// Επιστρέφει την τρέχουσα ημερομηνία και ώρα.
        /// </summary>
        DateTime GetCurrentDateTime();

        /// <summary>
        /// Επιστρέφει την τρέχουσα ημερομηνία.
        /// </summary>
        DateTime GetCurrentDate();

        /// <summary>
        /// Επιστρέφει την τρέχουσα ώρα.
        /// </summary>
        TimeSpan GetCurrentTime();
    }
}
