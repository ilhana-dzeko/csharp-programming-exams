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

namespace cSharpIntroWinForms.Solution
{
    public partial class frmIzvjestaj : Form
    {
        private Korisnik korisnik;
        private GodineStudija godina;
        public frmIzvjestaj()
        {
            InitializeComponent();
        }

        public frmIzvjestaj(Korisnik korisnik, GodineStudija godina) : this()
        {
            this.korisnik = korisnik;
            this.godina = godina;
        }

        private void frmIzvjestaj_Load(object sender, EventArgs e)
        {
            ReportParameterCollection rpt = new ReportParameterCollection();
            rpt.Add(new ReportParameter("Ime", korisnik.Ime));
            rpt.Add(new ReportParameter("Prezime", korisnik.Prezime));
            rpt.Add(new ReportParameter("GodinaStudija", godina.Naziv));

            var tblPolozeniNovi = new dsPolozeniPredmeti.PolozeniPredmetiDataTable();
            foreach (var item in korisnik.Uspjeh)
            {
                if (item.GodinaStudija != null)
                {
                    if (godina.Id == item.GodinaStudija.Id)
                    {
                        var red = tblPolozeniNovi.NewPolozeniPredmetiRow();

                        red.Predmet = item.Predmet.Naziv;
                        red.Ocjena = item.Ocjena;
                        red.Datum = item.Datum.ToString();
                        
                        tblPolozeniNovi.Rows.Add(red);
                    }
                }
            }
            var rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = tblPolozeniNovi;



            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(rpt);

            this.reportViewer1.RefreshReport();
        }
    }
}
