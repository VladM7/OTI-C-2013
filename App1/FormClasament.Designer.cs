namespace App1
{
    partial class FormClasament
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewClasament = new System.Windows.Forms.DataGridView();
            this.NumeUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimpJoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumarPatratele = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stergere = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasament)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClasament
            // 
            this.dataGridViewClasament.AllowUserToAddRows = false;
            this.dataGridViewClasament.AllowUserToDeleteRows = false;
            this.dataGridViewClasament.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClasament.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeUser,
            this.TimpJoc,
            this.NumarPatratele,
            this.Stergere});
            this.dataGridViewClasament.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewClasament.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewClasament.Name = "dataGridViewClasament";
            this.dataGridViewClasament.ReadOnly = true;
            this.dataGridViewClasament.RowHeadersWidth = 123;
            this.dataGridViewClasament.RowTemplate.Height = 46;
            this.dataGridViewClasament.Size = new System.Drawing.Size(1331, 975);
            this.dataGridViewClasament.TabIndex = 0;
            this.dataGridViewClasament.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClasament_CellContentClick);
            // 
            // NumeUser
            // 
            this.NumeUser.HeaderText = "Nume user";
            this.NumeUser.MinimumWidth = 15;
            this.NumeUser.Name = "NumeUser";
            this.NumeUser.ReadOnly = true;
            this.NumeUser.Width = 300;
            // 
            // TimpJoc
            // 
            this.TimpJoc.HeaderText = "Timp joc";
            this.TimpJoc.MinimumWidth = 15;
            this.TimpJoc.Name = "TimpJoc";
            this.TimpJoc.ReadOnly = true;
            this.TimpJoc.Width = 300;
            // 
            // NumarPatratele
            // 
            this.NumarPatratele.HeaderText = "Numar patratele";
            this.NumarPatratele.MinimumWidth = 15;
            this.NumarPatratele.Name = "NumarPatratele";
            this.NumarPatratele.ReadOnly = true;
            this.NumarPatratele.Width = 300;
            // 
            // Stergere
            // 
            this.Stergere.HeaderText = "Stergere";
            this.Stergere.MinimumWidth = 15;
            this.Stergere.Name = "Stergere";
            this.Stergere.ReadOnly = true;
            this.Stergere.Width = 300;
            // 
            // FormClasament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 975);
            this.Controls.Add(this.dataGridViewClasament);
            this.Name = "FormClasament";
            this.Text = "FormClasament";
            this.Load += new System.EventHandler(this.FormClasament_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasament)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewClasament;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimpJoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumarPatratele;
        private System.Windows.Forms.DataGridViewButtonColumn Stergere;
    }
}