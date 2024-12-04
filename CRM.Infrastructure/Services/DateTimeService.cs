using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Services
{
    using CRM.Abstractions.Services;
    using System;

    public class DateTimeService : IDateTimeService
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now; // Returns current date and time
        }

        public DateTime GetCurrentDate()
        {
            return DateTime.Now.Date; // Returns only the date
        }

        public TimeSpan GetCurrentTime()
        {
            return DateTime.Now.TimeOfDay; // Returns only the time
        }
    }

}
