using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWindCoreLibrary.Models
{
    [Table("ContactType")]
    public partial class ContactType
    {
        public ContactType()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        public int ContactTypeIdentifier { get; set; }
        public string ContactTitle { get; set; }

        [InverseProperty("ContactTypeIdentifierNavigation")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}