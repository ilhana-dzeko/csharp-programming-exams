using DLWMS.WinForms.Entiteti;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DLWMS.WinForms.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private List<Student> studenti;
        private List<StudentiPredmeti> sp;

                  
        public frmIzvjestaji() 
        {
            InitializeComponent();
        }
        public frmIzvjestaji(List<Student> list) : this()
        {
            studenti = list;
        }  
        public frmIzvjestaji(List<StudentiPredmeti> list) : this()
        {
            this.sp = list;
        }

        private void frmIzvjestaji_Load(object sender, System.EventArgs e)
        {
            if (studenti != null)
            {
                int RB = 1;
                var tbl = new dsDLWMS.StudentiDataTable();
                
                foreach (var item in studenti)
                {
                    var red = tbl.NewStudentiRow();
                    red.RB = RB++;
                    red.Indeks = item.Indeks;
                    red.Ime = item.Ime;
                    red.Prezime = item.Prezime;
                    red.Spol = item.Spol.Naziv;
                    red.GodinaStudija = item.GodinaStudija;
                    red.Aktivan = item.Aktivan ? "Da" : "Ne";

                    tbl.AddStudentiRow(red);

                }
                var rds = new ReportDataSource();
                rds.Value = tbl;
                rds.Name = "dSetStudenti";

                reportViewer1.LocalReport.DataSources.Add(rds);
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
