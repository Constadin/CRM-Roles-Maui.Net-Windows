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
        /// Gets the current date and time.
        /// </summary>
        DateTime GetCurrentDateTime();

        /// <summary>
        /// Gets the current date.
        /// </summary>
        DateTime GetCurrentDate();

        /// <summary>
        /// Gets the current time.
        /// </summary>
        TimeSpan GetCurrentTime();
    }

}
