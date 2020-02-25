using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWindCoreLibrary.Contexts;
using NorthWindCoreLibrary.Extensions;
using NorthWindCoreLibrary.Models;

namespace NorthWindCoreLibrary.Demonstrations
{
    public class StaticCodeSamples
    {
        /// <summary>
        /// Incredibly bad for performance and unnecessary  to first
        /// ask for all records using .ToList then using .FirstOrDefault
        /// Eliminate .ToList
        ///
        /// Imagine performance with 100,000 records
        /// </summary>
        /// <param name="customerIdentfier"></param>
        /// <returns></returns>
        public Customer GetCustomerByIdentifierBad1(int customerIdentfier)
        {
            using (var context = new NorthwindContext())
            {
                return context.Customers.ToList()
                    .FirstOrDefault(customer =>
                        customer.CustomerIdentifier == customerIdentfier);
            }
        }
        /// <summary>
        /// Simply use FirstOrDefault.
        /// </summary>
        /// <param name="customerIdentfier"></param>
        /// <returns></returns>
        public Customer GetCustomerByIdentifierBad2(int customerIdentfier)
        {
            using (var context = new NorthwindContext())
            {

                // ReSharper disable once ReplaceWithSingleCallToFirstOrDefault
                return context.Customers
                    .Where(customer => customer.CustomerIdentifier == customerIdentfier)
                    .FirstOrDefault();
            }
        }
        public Customer GetCustomerByIdentifier(int customerIdentfier)
        {
            using (var context = new NorthwindContext())
            {
                return context.Customers
                    .FirstOrDefault(customer => 
                        customer.CustomerIdentifier == customerIdentfier);
            }
        }
        public async Task<Customer> GetCustomerByIdentifierAsync(int customerIdentfier)
        {
            using (var context = new NorthwindContext())
            {
                return await context.Customers
                    .FirstOrDefaultAsync(customer => 
                        customer.CustomerIdentifier == customerIdentfier);
            }
        }

        public List<Customer> GetCustomersForListBox()
        {
            using (var context = new NorthwindContext())
            {
                return context.Customers.ToList();
            }
        }

        /// <summary>
        /// Used to get into overrides for SaveChanges in NorthWindContext
        /// </summary>
        public async void ChangeCustomer1()
        {
            using (var context = new NorthwindContext())
            {
                var customer = context.Customers.FirstOrDefault();
                customer.CompanyName = null; 
                await context.SaveChangesWithValidationAsync();
            }
        }

    }
}
