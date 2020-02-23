using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWindCoreLibrary.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerIdentifier { get; set; }
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [StringLength(30)]
        public string ContactName { get; set; }
        public int? ContactId { get; set; }
        [StringLength(60)]
        public string Address { get; set; }
        [StringLength(15)]
        public string City { get; set; }
        [StringLength(15)]
        public string Region { get; set; }
        [StringLength(10)]
        public string PostalCode { get; set; }
        public int? CountryIdentifier { get; set; }
        [StringLength(24)]
        public string Phone { get; set; }
        [StringLength(24)]
        public string Fax { get; set; }
        public int? ContactTypeIdentifier { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("ContactId")]
        [InverseProperty("Customers")]
        public virtual Contact Contact { get; set; }
        [ForeignKey("ContactTypeIdentifier")]
        [InverseProperty("Customers")]
        public virtual ContactType ContactTypeIdentifierNavigation { get; set; }
        [ForeignKey("CountryIdentifier")]
        [InverseProperty("Customers")]
        public virtual Country CountryIdentifierNavigation { get; set; }
        [InverseProperty("CustomerIdentifierNavigation")]
        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString() => CompanyName;

    }
}