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

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ToroidalBoundry_CheckedChanged(object sender, EventArgs e)
        {
            //initialize button function
        }

        private void FiniteBoundry_CheckedChanged(object sender, EventArgs e)
        {
            //initialize button function
        }
    }
}
