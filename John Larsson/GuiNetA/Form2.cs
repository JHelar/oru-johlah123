using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiNetA
{
    public partial class HeltalIn : Form
    {
        public int data;
        public HeltalIn()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.data = System.Convert.ToInt32(this.textBox1.Text);
            this.Close();
        }

        private void CancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
