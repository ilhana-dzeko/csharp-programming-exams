
namespace DLWMS.WinForms.Izvjestaji
{
    partial class frmIzvjestaji
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
            this.components = new System.ComponentModel.Container();
            this.PorukeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.StudentiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsDLWMS = new DLWMS.WinForms.Izvjestaji.dsDLWMS();
            ((System.ComponentModel.ISupportInitialize)(this.PorukeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDLWMS)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DLWMS.WinForms.Izvjestaji.rptStudenti.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(713, 632);
            this.reportViewer1.TabIndex = 0;
            // 
            // StudentiBindingSource
            // 
            this.StudentiBindingSource.DataMember = "Studenti";
            this.StudentiBindingSource.DataSource = this.dsDLWMS;
            // 
            // dsDLWMS
            // 
            this.dsDLWMS.DataSetName = "dsDLWMS";
            this.dsDLWMS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmIzvjestaji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 632);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmIzvjestaji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIzvjestaji";
            this.Load += new System.EventHandler(this.frmIzvjestaji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PorukeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDLWMS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PorukeBindingSource;
        private System.Windows.Forms.BindingSource StudentiBindingSource;
        private dsDLWMS dsDLWMS;
    }
}