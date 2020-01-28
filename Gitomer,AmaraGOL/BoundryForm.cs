using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gitomer_AmaraGOL
{
    public partial class BoundryForm : Form
    {
        public BoundryForm()
        {
            InitializeComponent();
        }
        public bool Boundry
        {
            //bool true = toroidal
            get;
            set;
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (ToroidalBoundry.Enabled)
            {
                Boundry = true;
            }
            else
                Boundry = false;
            DialogResult = DialogResult.OK;
        }
    }
}
