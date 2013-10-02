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
    public partial class Form1 : Form
    {
        private HeltalIn Heltal=new HeltalIn();
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void läsInHeltal_Click(object sender, EventArgs e)
        {
            this.Heltal.ShowDialog();
        }

        private void skrivHeltalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Heltal.data != 0)
                MessageBox.Show(System.Convert.ToString(Heltal.data), "HeltalsData");
            else
                MessageBox.Show("Inget Heltal är angivet!", "Fel!");
        }

        private void avslutaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
