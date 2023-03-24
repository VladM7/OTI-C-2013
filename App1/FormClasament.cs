using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1
{
    public partial class FormClasament : Form
    {
        public List<string[]> Clasament {  get; set; }
        public bool Admin { get; set; }

        public FormClasament(bool admin)
        {
            InitializeComponent();
            Clasament = new List<string[]>();
            if (!admin)
            {
                dataGridViewClasament.Columns.RemoveAt(3);
            }
            Admin = admin;
        }

        private void FormClasament_Load(object sender, EventArgs e)
        {
            Clasament.Clear();
            if(File.Exists("clasament.txt"))
            {
                var lines=File.ReadAllLines("clasament.txt");
                foreach(var line in lines)
                {
                    Clasament.Add(line.Split(' '));
                }
                Clasament.Sort((e1, e2) =>
                {
                    var timp1 = e1[1];
                    var timp2 = e2[1];
                    var ora1 = int.Parse(timp1.Split(':')[0]);
                    var minut1 = int.Parse(timp1.Split(':')[1]);
                    var ora2 = int.Parse(timp2.Split(':')[0]);
                    var minut2 = int.Parse(timp2.Split(':')[1]);
                    if(ora1!=ora2)
                    {
                        return ora1.CompareTo(ora2);
                    }
                    else
                    {
                        return minut1.CompareTo(minut2);
                    }
                });
                foreach(var line in Clasament)
                {
                    if(!Admin)
                    {
                        dataGridViewClasament.Rows.Add(line);
                    }
                    else
                    {
                        dataGridViewClasament.Rows.Add(new string[] { line[0], line[1], line[2], "Sterge" });
                    }
                }
            }
        }

        private void dataGridViewClasament_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                //click pe butonul de stergere
                Clasament.RemoveAt(e.RowIndex);
                dataGridViewClasament.Rows.RemoveAt(e.RowIndex);
                using (var file = new StreamWriter("clasament.txt")) 
                { 
                    foreach(var line in Clasament)
                    {
                        file.WriteLine(string.Format("{0} {1} {2}", line[0], line[1], line[2]));
                    }
                }
            }
        }
    }
}
