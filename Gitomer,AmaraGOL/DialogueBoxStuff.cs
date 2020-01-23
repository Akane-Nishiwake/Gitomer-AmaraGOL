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
    public partial class DialogueBoxStuff : Form
    {
        public DialogueBoxStuff()
        {
            InitializeComponent();
            Width = Form1.X;
            Height = Form1.Y;
        }
        public int Time 
        {
            get
            {
                return (int)numericUpDown1.Value;
            }
            set
            {
                numericUpDown1.Value = value;
            }
        }
        public int Height
        {
            get
            {
                return (int)numericUpDown2.Value;
            }
            set
            {
                numericUpDown2.Value = value;
            }
        }
        public int Width
        {
            get
            {
                return (int)numericUpDown3.Value;
            }
            set
            {
                numericUpDown3.Value = value;
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)//time
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)//height
        {
            Height = (int)numericUpDown2.Value;
            Form1.Y = Height;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)//width
        {
            Width = (int)numericUpDown3.Value;
            Form1.X = Height;
        }
    }
}
