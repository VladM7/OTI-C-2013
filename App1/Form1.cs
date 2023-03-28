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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var optiuni = new List<string> { "jucator", "administrator" };
            if (optiuni[comboBoxLogin.SelectedIndex] == textBoxParola.Text)
            {
                var meniu = new Form2(comboBoxLogin.SelectedIndex==1);
                meniu.Show();
                this.Hide();
                meniu.FormClosed += (s, args) =>
                {
                    this.Show();
                };
            }
            else
            {
                MessageBox.Show("Detalii gresite!");
            }
            textBoxParola.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
