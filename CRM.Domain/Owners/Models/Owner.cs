using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Owners.Models
{
    public class Owner
    {
        public int? OwnerID { get; set; }
        public string? LastName { get; set; } = "Nio";
        public string? FirstName { get; set; } = "loras";
        public string? PhoneNumber { get; set; } = "6985414525";
    }
}
