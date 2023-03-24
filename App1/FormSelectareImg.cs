using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1
{
    public partial class FormSelectareImg : Form
    {
        public int nrPatratele = 4;
        public string[] imagini4 = new string[] { "image4", "image6" };
        public string[] imagini9 = new string[] { "image1", "image2", "image3", "image5" };

        public FormSelectareImg()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(imagini4);
        }

        private void patratele_Changed(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                nrPatratele = int.Parse(((RadioButton)sender).Text);
                comboBox1.Items.Clear();
                if (nrPatratele == 4)
                    comboBox1.Items.AddRange(imagini4);
                else
                    comboBox1.Items.AddRange(imagini9);
                comboBox1.SelectedIndex = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = string.Format("Img/{0}/{0}.jpg", comboBox1.SelectedItem);
        }
    }
}
