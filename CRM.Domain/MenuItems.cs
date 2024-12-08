using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public static class MenuItems
    {
        public static readonly List<(string PageKey, string Title)> Items = new List<(string PageKey, string Title)>
        {
            ("DashboardViewPage", "Dashboard"),
            ("CallCenterViewPage", "Call Center"),
            ("MainPage", "Companies")            
        };
    }
}
