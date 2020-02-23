using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWindCoreLibrary.Contexts;
using NorthWindCoreLibrary.HelperClasses;
using NorthWindCoreLibrary.Models;

namespace NorthWindCoreLibrary.Extensions
{
    public static class CustomerExtensions
    {
        public static async Task<Customer> CustomerPartial(this NorthwindContext context, int customerIdentifier)
        {
            return  await context.Customers
                .AsNoTracking()
                .Include(customer => customer.CountryIdentifierNavigation)
                .Include(customer => customer.Contact)
                .Include(customer => customer.ContactTypeIdentifierNavigation)
                .FirstOrDefaultAsync(cust => cust.CustomerIdentifier == customerIdentifier);
        }

        public static async Task<List<CustomerLister>> CustomerDisplay(this NorthwindContext context)
        {
            return await context.Customers
                .AsNoTracking()
                .Select(customer => new CustomerLister
                {
                    Name = customer.CompanyName,
                    Id = customer.CustomerIdentifier
                }).ToListAsync();
        }
    }
}
