using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWindCoreLibrary.Models
{
    public partial class Country
    {
        public Country()
        {
            Customers = new HashSet<Customer>();
            Suppliers = new HashSet<Supplier>();
        }

        [Key]
        public int CountryIdentifier { get; set; }
        public string Name { get; set; }

        [InverseProperty("CountryIdentifierNavigation")]
        public virtual ICollection<Customer> Customers { get; set; }
        [InverseProperty("CountryIdentifierNavigation")]
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}