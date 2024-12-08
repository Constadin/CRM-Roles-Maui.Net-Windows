using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Services
{
    using CRM.Abstractions.Services;

    public class DateTimeService : IDateTimeService
    {
        // Επιστρέφει την τρέχουσα ημερομηνία και ώρα
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

        // Επιστρέφει μόνο την τρέχουσα ημερομηνία
        public DateTime GetCurrentDate()
        {
            return DateTime.Now.Date;
        }

        // Επιστρέφει μόνο την τρέχουσα ώρα
        public TimeSpan GetCurrentTime()
        {
            return DateTime.Now.TimeOfDay;
        }
    }
}
