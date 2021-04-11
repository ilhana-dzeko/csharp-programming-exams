using cSharpIntroWinForms.P10;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static cSharpIntroWinForms.Solution.dsPolozeni;

namespace cSharpIntroWinForms.Solution
{
    public partial class frmIzvjestaj : Form
    {
        private List<KorisniciPredmeti> polozeniPredmeti;

        public frmIzvjestaj()
        {
            InitializeComponent();
        }

        public frmIzvjestaj(List<KorisniciPredmeti> list) : this()
        {
            this.polozeniPredmeti = list;
        }

        private void frmIzvjestaj_Load(object sender, EventArgs e)
        {
            var tblPolozeni = new PolozeniDataTable();

            foreach (var predmet in polozeniPredmeti)
            {
                    var red = tblPolozeni.NewPolozeniRow();

                    red.Ime = predmet.Korisnik.Ime;
                    red.Prezime = predmet.Korisnik.Prezime;
                    red.Predmet = predmet.Predmet.Naziv;
                    red.Ocjena = predmet.Ocjena;
                    red.Datum = predmet.Datum;

                    tblPolozeni.Rows.Add(red);
             
            }

            ReportDataSource rds = new ReportDataSource
            {
                Value = tblPolozeni,
                Name = "DataSetPolozeni"
            };

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
