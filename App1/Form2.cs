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
    public partial class Form2 : Form
    {
        public bool Admin { get; set; }

        public Form2(bool admin)
        {
            InitializeComponent();
            if(admin)
            {
                buttonClasament.Visible= false;
                button1.Text = "Editare clasament";
            }
            Admin= admin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Admin)
            {
                //editare clasament
                buttonClasament_Click(sender, e);
            }
            else
            {
                //joc nou
                if(string.IsNullOrEmpty(textBoxUsername.Text))
                {
                    MessageBox.Show("Alege un username!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var selectareImg = new FormSelectareImg();
                    selectareImg.ShowDialog();
                    if (selectareImg.ImagineSelectata != null) {
                        // open game window
                        var game = new FormGame(textBoxUsername.Text, selectareImg.nrPatratele, selectareImg.ImagineSelectata);
                        game.Show();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonClasament_Click(object sender, EventArgs e)
        {
            var clasament=new FormClasament(Admin);
            clasament.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
