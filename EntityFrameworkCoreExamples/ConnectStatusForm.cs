using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkCoreExamples
{
    public partial class ConnectStatusForm : Form
    {
        public ConnectStatusForm()
        {
            InitializeComponent();
            Shown += ConnectStatusForm_Shown;
        }

        private void ConnectStatusForm_Shown(object sender, EventArgs e)
        {
            CenterToParent();
        }
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}
