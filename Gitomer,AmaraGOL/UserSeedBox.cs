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
    public partial class UserSeedBox : Form
    {
        public UserSeedBox()
        {
            InitializeComponent();

        }
        public int UserSeedInput
        {
            get
            {
                return (int)UserSeedGenerator.Value;
            }
            set
            {
                UserSeedGenerator.Value = value;
            }
        }

        private void UserSeedGenerator_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Randomize_Click(object sender, EventArgs e)
        {
            Random randy = new Random();
            UserSeedGenerator.Value = randy.Next() % UserSeedGenerator.Maximum;
            
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
