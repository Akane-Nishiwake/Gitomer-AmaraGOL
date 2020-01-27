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
    public partial class SaveASDialogue : Form
    {
        public SaveASDialogue()
        {
            InitializeComponent();
        }

        public string Filter { get; internal set; }
        public int FilterIndex { get; internal set; }
        public string DefaultExt { get; internal set; }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
