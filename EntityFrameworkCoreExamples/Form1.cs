using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using NorthWindCoreLibrary.Contexts;
using NorthWindCoreLibrary.Extensions;
using NorthWindCoreLibrary.HelperClasses;

namespace EntityFrameworkCoreExamples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }
        /// <summary>
        /// Load ListBox with CompanyName and primary key used for returning
        /// customer by primary key to demonstrate using .Include
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_Shown(object sender, EventArgs e)
        {
            var waitForm = new ConnectStatusForm() {Top = Top, Left = Left, TopMost = true};

            await Task.Delay(20);

            waitForm.Show();

            await Task.Delay(10);

            using (var context = new NorthwindContext())
            {

                // set to true for logging Entity Framework operations
                // for this instance of the DbContext.
                // context.Diagnostics = true;
               
                try
                {
                    if (await context.Database.CanConnectAsync())
                    {
                        var results = await context.CustomerDisplay();
                        CustomerListBox.DataSource = results;

                        IncludeStatementsConventionalButton.Enabled = true;
                        IncludeStatementsUsingExtensionButton.Enabled = true;

                    }
                    else
                    {
                        waitForm.Close();                       
                        MessageBox.Show("Failed to connection to server, please check the connection string.");
                    }
                }
                catch (Exception ex)
                {
                    waitForm.Close();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    waitForm.Dispose();
                }

            }

        }

        /// <summary>
        /// Conventional method to return data with eager loading which becomes polluted with
        /// Include statements and also means if requirements change for what is included all
        /// instances of the code need changing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void IncludeStatementsConventionalButton_Click(object sender, EventArgs e)
        {

            var customerIdentifier = ((CustomerLister)CustomerListBox.SelectedItem).Id;

            using (var context = new NorthwindContext())
            {
                var customer = await context.Customers
                    .Include(cust => cust.CountryIdentifierNavigation)
                    .Include(cust => cust.Contact)
                    .Include(cust => cust.ContactTypeIdentifierNavigation)
                    .FirstOrDefaultAsync(cust => cust.CustomerIdentifier == customerIdentifier);

                FirstNameTextBox.Text = customer.Contact.FirstName;
                LastNameTextBox.Text = customer.Contact.LastName;
                ContactTypeTextBox.Text = customer.ContactTypeIdentifierNavigation.ContactTitle;
                CountryTextBox.Text = customer.CountryIdentifierNavigation.Name;

            }
        }

        /// <summary>
        /// Reusable method to query data, unlike the example above changes are made in
        /// one place in code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void IncludeStatementsUsingExtensionButton_Click(object sender, EventArgs e)
        {
            var customerIdentifier = ((CustomerLister)CustomerListBox.SelectedItem).Id; ;

            using (var context = new NorthwindContext())
            {

                context.Diagnostics = LogConsoleCheckBox.Checked;
                var customer = await context.CustomerPartial(customerIdentifier);

                FirstNameTextBox.Text = customer.Contact.FirstName;
                LastNameTextBox.Text = customer.Contact.LastName;
                ContactTypeTextBox.Text = customer.ContactTypeIdentifierNavigation.ContactTitle;
                CountryTextBox.Text = customer.CountryIdentifierNavigation.Name;

            }

            /*
             * Alternate to using an extension method as per above
             */
            using (var context = new NorthwindContext())
            {
                var customer = await CustomerHelpers.CustomerEntityAsync(context, customerIdentifier);
            }

        }
    }
}
