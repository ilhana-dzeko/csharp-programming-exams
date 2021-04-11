namespace DLWMS.WinForms.Forme
{
    partial class frmStudentiPotvrde
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
            this.txtGenerisi = new System.Windows.Forms.TextBox();
            this.btnGenerisi = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.BtnUpisiUFajl = new System.Windows.Forms.Button();
            this.dgvStudentiPotvrde = new System.Windows.Forms.DataGridView();
            this.Student = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Svrha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Izdata = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBrPotvrda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentiPotvrde)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGenerisi
            // 
            this.txtGenerisi.Location = new System.Drawing.Point(23, 12);
            this.txtGenerisi.Name = "txtGenerisi";
            this.txtGenerisi.Size = new System.Drawing.Size(158, 20);
            this.txtGenerisi.TabIndex = 0;
            // 
            // btnGenerisi
            // 
            this.btnGenerisi.Location = new System.Drawing.Point(187, 10);
            this.btnGenerisi.Name = "btnGenerisi";
            this.btnGenerisi.Size = new System.Drawing.Size(99, 23);
            this.btnGenerisi.TabIndex = 1;
            this.btnGenerisi.Text = "Generisi potvrde";
            this.btnGenerisi.UseVisualStyleBackColor = true;
            this.btnGenerisi.Click += new System.EventHandler(this.btnGenerisi_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(401, 12);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(97, 23);
            this.btnObrisi.TabIndex = 2;
            this.btnObrisi.Text = "Obrisi potvrde";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // BtnUpisiUFajl
            // 
            this.BtnUpisiUFajl.Location = new System.Drawing.Point(558, 12);
            this.BtnUpisiUFajl.Name = "BtnUpisiUFajl";
            this.BtnUpisiUFajl.Size = new System.Drawing.Size(127, 23);
            this.BtnUpisiUFajl.TabIndex = 3;
            this.BtnUpisiUFajl.Text = "Spasi u fajl";
            this.BtnUpisiUFajl.UseVisualStyleBackColor = true;
            this.BtnUpisiUFajl.Click += new System.EventHandler(this.BtnUpisiUFajl_Click);
            // 
            // dgvStudentiPotvrde
            // 
            this.dgvStudentiPotvrde.AllowUserToAddRows = false;
            this.dgvStudentiPotvrde.AllowUserToDeleteRows = false;
            this.dgvStudentiPotvrde.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentiPotvrde.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Student,
            this.Datum,
            this.Svrha,
            this.Izdata});
            this.dgvStudentiPotvrde.Location = new System.Drawing.Point(23, 52);
            this.dgvStudentiPotvrde.Name = "dgvStudentiPotvrde";
            this.dgvStudentiPotvrde.ReadOnly = true;
            this.dgvStudentiPotvrde.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudentiPotvrde.Size = new System.Drawing.Size(662, 250);
            this.dgvStudentiPotvrde.TabIndex = 4;
            // 
            // Student
            // 
            this.Student.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Student.DataPropertyName = "Student";
            this.Student.HeaderText = "Student";
            this.Student.Name = "Student";
            this.Student.ReadOnly = true;
            // 
            // Datum
            // 
            this.Datum.DataPropertyName = "Datum";
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // Svrha
            // 
            this.Svrha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Svrha.DataPropertyName = "Svrha";
            this.Svrha.HeaderText = "Svrha";
            this.Svrha.Name = "Svrha";
            this.Svrha.ReadOnly = true;
            // 
            // Izdata
            // 
            this.Izdata.DataPropertyName = "Izdata";
            this.Izdata.HeaderText = "Izdata";
            this.Izdata.Name = "Izdata";
            this.Izdata.ReadOnly = true;
            this.Izdata.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Izdata.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Trenutno potvrda:";
            // 
            // lblBrPotvrda
            // 
            this.lblBrPotvrda.AutoSize = true;
            this.lblBrPotvrda.Location = new System.Drawing.Point(118, 317);
            this.lblBrPotvrda.Name = "lblBrPotvrda";
            this.lblBrPotvrda.Size = new System.Drawing.Size(0, 13);
            this.lblBrPotvrda.TabIndex = 6;
            // 
            // frmStudentiPotvrde
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 339);
            this.Controls.Add(this.lblBrPotvrda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStudentiPotvrde);
            this.Controls.Add(this.BtnUpisiUFajl);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnGenerisi);
            this.Controls.Add(this.txtGenerisi);
            this.Name = "frmStudentiPotvrde";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStudentiPotvrde";
            this.Load += new System.EventHandler(this.frmStudentiPotvrde_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentiPotvrde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGenerisi;
        private System.Windows.Forms.Button btnGenerisi;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button BtnUpisiUFajl;
        private System.Windows.Forms.DataGridView dgvStudentiPotvrde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Student;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Svrha;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Izdata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBrPotvrda;
    }
}