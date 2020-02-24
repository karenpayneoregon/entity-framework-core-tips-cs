using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecureConnection.Classes;
using static System.Configuration.ConfigurationManager;

namespace SecureConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Reading connection string not encrypted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetNormalButton_Click(object sender, EventArgs e)
        {
            var test = ConnectionStrings;
            Console.WriteLine(ConnectionStrings["ConnectionString"].ConnectionString);
        }

        private void SecureStringButton_Click(object sender, EventArgs e)
        {
            // how to encrypt connection string
            var result = ConfigSecurity.EncryptString(ConfigSecurity.ToSecureString(
                ConnectionStrings["ConnectionString"].ConnectionString));

            Console.WriteLine(result);

            // how to decrypt connection string
            var unSecure = ConfigSecurity.DecryptString(result);
            Console.WriteLine(ConfigSecurity.ToInsecureString(unSecure));
        }
    }
}
