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

namespace App1 {
    public partial class FormGame : Form {
        public int[,] bucati = new int[3, 3] {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 }
        };
        private PictureBox[,] imagini2;        
        private PictureBox[,] imagini3;        
        public int Marime { get; set; }
        public string Imagine { get; set; }
        public DateTime? OraPornire = null;
        public DateTime? OraTerminare = null;

        public string Nume { get; set; }

        private Random random = new Random();

        public FormGame(string nume, int marime, string imagine) {
            InitializeComponent();
            Nume = nume;
            Marime = (int)Math.Sqrt(marime);
            Imagine = imagine;
            imagini2 = new PictureBox[2, 2] {
                { pictureBox2_0_0, pictureBox2_0_1 },
                { pictureBox2_1_0, pictureBox2_1_1 }
            };
            imagini3 = new PictureBox[3, 3] {
                { pictureBox3_0_0, pictureBox3_0_1, pictureBox3_0_2 },
                { pictureBox3_1_0, pictureBox3_1_1, pictureBox3_1_2 },
                { pictureBox3_2_0, pictureBox3_2_1, pictureBox3_2_2 }
            };

            if (Marime == 2) {
                tableLayoutPanel3.Visible = false;
            }
            else {
                tableLayoutPanel2.Visible = false;
            }

            foreach (var pictureBox in imagini2) {
                pictureBox.AllowDrop = true;
                pictureBox.MouseDown += pictureBox_MouseDown;
                pictureBox.DragEnter += pictureBox_DragEnter;
                pictureBox.DragDrop += pictureBox_DragDrop;
            }
            foreach (var pictureBox in imagini3) {
                pictureBox.AllowDrop = true;
                pictureBox.MouseDown += pictureBox_MouseDown;
                pictureBox.DragEnter += pictureBox_DragEnter;
                pictureBox.DragDrop += pictureBox_DragDrop;
            }
        }

        private void FormGame_Load(object sender, EventArgs e) {
            var indiciRamasi = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            if (Marime == 2) {
                indiciRamasi = new List<int> { 0, 1, 2, 3 };
            }
            for (int i = 0; i < Marime; i++) {
                for (int j = 0; j < Marime; j++) {
                    int indiceSelectat = random.Next(indiciRamasi.Count);
                    bucati[i, j] = indiciRamasi[indiceSelectat];
                    indiciRamasi.RemoveAt(indiceSelectat);
                }
            }
            RedeseneazaPoze();
        }

        private void RedeseneazaPoze() {
            for (int i = 0; i < Marime; i++) {
                for (int j = 0; j < Marime; j++) {
                    var iNou = bucati[i, j] / Marime;
                    var jNou = bucati[i, j] % Marime;
                    var locImg = string.Format("Img/{0}/{0}-{1}-{2}.jpeg", Imagine, iNou, jNou);
                    if (i < 2 && j < 2) {
                        imagini2[i, j].ImageLocation = locImg;
                    }
                    imagini3[i, j].ImageLocation = locImg;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            var durataJoc = TimeSpan.Zero;
            if (OraPornire != null) {
                durataJoc = (TimeSpan)(DateTime.Now - OraPornire);
            }
            if (OraTerminare != null) {
                durataJoc = (TimeSpan)(OraTerminare - OraPornire);
            }
            labelDurata.Text = string.Format("Durata joc: {0:00}:{1:00}", durataJoc.Minutes, durataJoc.Seconds);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
            int indice = 0;
            for (int i = 0; i < Marime; i++) {
                for (int j = 0; j < Marime; j++) {
                    if (Marime == 2) {
                        if (sender == imagini2[i, j]) {
                            indice = i * Marime + j;
                            break;
                        }
                    }
                    else {
                        if (sender == imagini3[i, j]) {
                            indice = i * Marime + j;
                            break;
                        }
                    }
                }
            }
            (sender as PictureBox).DoDragDrop(indice.ToString(), DragDropEffects.Move);
        }

        private void pictureBox_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.Text)) {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void pictureBox_DragDrop(object sender, DragEventArgs e) {
            int indice = int.Parse(e.Data.GetData(DataFormats.Text).ToString());
            int iVechi = indice / Marime;
            int jVechi = indice % Marime;

            int iNou = 0, jNou = 0;
            for (int i = 0; i < Marime; i++) {
                for (int j = 0; j < Marime; j++) {
                    if (Marime == 2) {
                        if (sender == imagini2[i, j]) {
                            iNou = i;
                            jNou = j;
                            break;
                        }
                    }
                    else {
                        if (sender == imagini3[i, j]) {
                            iNou = i;
                            jNou = j;
                            break;
                        }
                    }
                }
            }

            var temp = bucati[iNou, jNou];
            bucati[iNou, jNou] = bucati[iVechi, jVechi];
            bucati[iVechi, jVechi] = temp;

            if (OraPornire == null) {
                OraPornire = DateTime.Now;
            }

            RedeseneazaPoze();

            bool rezolvat = true;
            for (int i = 0; i < Marime; i++) {
                for (int j = 0; j < Marime; j++) {
                    if (bucati[i, j] != i * Marime + j) {
                        rezolvat = false;
                        break;
                    }
                }
            }
            if (rezolvat) {
                OraTerminare = DateTime.Now;
                var durataJoc = (TimeSpan)(OraTerminare - OraPornire);
                using (var file = File.AppendText("Clasament.txt")) {
                    file.WriteLine(string.Format("{0} {1:00}:{2:00} {3}", Nume, durataJoc.Minutes, durataJoc.Seconds, Marime * Marime));
                }
                MessageBox.Show("Ai rezolvat puzzle-ul!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            var image = pictureBox2_0_0.Image;
            var bitmap = new Bitmap(image);
            for (int i = 0; i < bitmap.Width; i++) {
            bitmap.GetPixel(i, 0);
            }
        }
    }
}
