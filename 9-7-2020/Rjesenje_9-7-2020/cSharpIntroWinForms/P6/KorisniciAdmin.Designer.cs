namespace cSharpIntroWinForms
{
    partial class KorisniciAdmin
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
            this.dgvKorisnici = new System.Windows.Forms.DataGridView();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnickoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Admin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Slike = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.cmbSpolovi = new System.Windows.Forms.ComboBox();
            this.cbAdministrator = new System.Windows.Forms.CheckBox();
            this.txtSuma = new System.Windows.Forms.TextBox();
            this.btnSuma = new System.Windows.Forms.Button();
            this.btnPrintajPolozene = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKorisnici
            // 
            this.dgvKorisnici.AllowUserToAddRows = false;
            this.dgvKorisnici.AllowUserToDeleteRows = false;
            this.dgvKorisnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKorisnici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ime,
            this.Prezime,
            this.Spol,
            this.KorisnickoIme,
            this.Admin,
            this.Slike});
            this.dgvKorisnici.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvKorisnici.Location = new System.Drawing.Point(12, 41);
            this.dgvKorisnici.Name = "dgvKorisnici";
            this.dgvKorisnici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKorisnici.Size = new System.Drawing.Size(666, 247);
            this.dgvKorisnici.TabIndex = 0;
            this.dgvKorisnici.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKorisnici_CellContentClick);
            // 
            // Ime
            // 
            this.Ime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            // 
            // Prezime
            // 
            this.Prezime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            // 
            // Spol
            // 
            this.Spol.DataPropertyName = "Spol";
            this.Spol.HeaderText = "Spol";
            this.Spol.Name = "Spol";
            // 
            // KorisnickoIme
            // 
            this.KorisnickoIme.DataPropertyName = "KorisnickoIme";
            this.KorisnickoIme.HeaderText = "Korisničko ime";
            this.KorisnickoIme.Name = "KorisnickoIme";
            // 
            // Admin
            // 
            this.Admin.DataPropertyName = "Admin";
            this.Admin.HeaderText = "Admin";
            this.Admin.Name = "Admin";
            // 
            // Slike
            // 
            this.Slike.HeaderText = "";
            this.Slike.Name = "Slike";
            this.Slike.Text = "Slike";
            this.Slike.UseColumnTextForButtonValue = true;
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(12, 15);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(414, 20);
            this.txtPretraga.TabIndex = 2;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // cmbSpolovi
            // 
            this.cmbSpolovi.FormattingEnabled = true;
            this.cmbSpolovi.Location = new System.Drawing.Point(438, 15);
            this.cmbSpolovi.Name = "cmbSpolovi";
            this.cmbSpolovi.Size = new System.Drawing.Size(148, 21);
            this.cmbSpolovi.TabIndex = 4;
            this.cmbSpolovi.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbAdministrator
            // 
            this.cbAdministrator.AutoSize = true;
            this.cbAdministrator.Location = new System.Drawing.Point(592, 18);
            this.cbAdministrator.Name = "cbAdministrator";
            this.cbAdministrator.Size = new System.Drawing.Size(86, 17);
            this.cbAdministrator.TabIndex = 5;
            this.cbAdministrator.Text = "Administrator";
            this.cbAdministrator.UseVisualStyleBackColor = true;
            this.cbAdministrator.CheckedChanged += new System.EventHandler(this.cbAdministrator_CheckedChanged);
            // 
            // txtSuma
            // 
            this.txtSuma.Location = new System.Drawing.Point(12, 295);
            this.txtSuma.Name = "txtSuma";
            this.txtSuma.Size = new System.Drawing.Size(215, 20);
            this.txtSuma.TabIndex = 6;
            // 
            // btnSuma
            // 
            this.btnSuma.Location = new System.Drawing.Point(233, 293);
            this.btnSuma.Name = "btnSuma";
            this.btnSuma.Size = new System.Drawing.Size(75, 23);
            this.btnSuma.TabIndex = 7;
            this.btnSuma.Text = "Suma";
            this.btnSuma.UseVisualStyleBackColor = true;
            this.btnSuma.Click += new System.EventHandler(this.btnSuma_Click);
            // 
            // btnPrintajPolozene
            // 
            this.btnPrintajPolozene.Location = new System.Drawing.Point(513, 292);
            this.btnPrintajPolozene.Name = "btnPrintajPolozene";
            this.btnPrintajPolozene.Size = new System.Drawing.Size(165, 23);
            this.btnPrintajPolozene.TabIndex = 8;
            this.btnPrintajPolozene.Text = "Printaj polozene";
            this.btnPrintajPolozene.UseVisualStyleBackColor = true;
            this.btnPrintajPolozene.Click += new System.EventHandler(this.btnPrintajPolozene_Click);
            // 
            // KorisniciAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 320);
            this.Controls.Add(this.btnPrintajPolozene);
            this.Controls.Add(this.btnSuma);
            this.Controls.Add(this.txtSuma);
            this.Controls.Add(this.cbAdministrator);
            this.Controls.Add(this.cmbSpolovi);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.dgvKorisnici);
            this.Name = "KorisniciAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KorisniciAdmin";
            this.Load += new System.EventHandler(this.KorisniciAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKorisnici;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.ComboBox cmbSpolovi;
        private System.Windows.Forms.CheckBox cbAdministrator;
        private System.Windows.Forms.TextBox txtSuma;
        private System.Windows.Forms.Button btnSuma;
        private System.Windows.Forms.Button btnPrintajPolozene;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnickoIme;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Admin;
        private System.Windows.Forms.DataGridViewButtonColumn Slike;
    }
}