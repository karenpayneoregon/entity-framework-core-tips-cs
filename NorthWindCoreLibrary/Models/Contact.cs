using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWindCoreLibrary.Models
{
    public partial class Contact
    {
        public Contact()
        {
            Customers = new HashSet<Customer>();
        }

        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [InverseProperty("Contact")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}