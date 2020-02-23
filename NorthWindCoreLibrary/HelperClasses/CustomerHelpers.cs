using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWindCoreLibrary.Contexts;
using NorthWindCoreLibrary.Models;

namespace NorthWindCoreLibrary.HelperClasses
{
    public class CustomerHelpers
    {
        public static async Task<Customer> CustomerEntityAsync(NorthwindContext context, int customerIdentifier)
        {
            return await context.Customers
                .Include(customer => customer.CountryIdentifierNavigation)
                .Include(customer => customer.Contact)
                .Include(customer => customer.ContactTypeIdentifierNavigation)
                .FirstOrDefaultAsync(cust => cust.CustomerIdentifier == customerIdentifier);
        }
    }
}