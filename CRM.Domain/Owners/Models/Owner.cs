using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Owners.Models
{
    public class Owner
    {
        // Primary key for the Owner entity
        public int OwnerId { get; set; }

        // Owner's last name
        public string? LastName { get; set; }

        // Owner's first name
        public string? FirstName { get; set; }

        // Owner's email address
        public string? Email { get; set; }

        // Hashed password for the owner
        public string? Password { get; set; }

        // Owner's username
        public string? Username { get; set; }

        // Owner's phone number
        public string? PhoneNumber { get; set; }

        // Owner's VAT number
        public string? VatNumber { get; set; }

        // Foreign key for the type of store
        public int? TypeOfStoreId { get; set; }

        // Navigation property for the related TypeOfStore entity
        //public TypeOfStore? TypeOfStore { get; set; }
    }


}
