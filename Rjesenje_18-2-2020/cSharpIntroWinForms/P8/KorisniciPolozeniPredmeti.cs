using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P9;
using cSharpIntroWinForms.Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace cSharpIntroWinForms.P8
{
    public partial class KorisniciPolozeniPredmeti : Form
    {
        private Korisnik korisnik;

        KonekcijaNaBazu konekcijaNaBazu = DLWMS.DB;

        public KorisniciPolozeniPredmeti()
        {
            InitializeComponent();
            dgvPolozeniPredmeti.AutoGenerateColumns = false;
        }

        public KorisniciPolozeniPredmeti(Korisnik korisnik) : this()
        {
            this.korisnik = korisnik;
        }

        private void KorisniciPolozeniPredmeti_Load(object sender, EventArgs e)
        {
            UcitajPredmete();
            UcitajPolozenePredmete();
            UcitajOcjene();
            UcitajGodine();
        }

        private void UcitajGodine()
        {
            cmbGodine.DataSource = null;
            cmbGodine.DataSource = konekcijaNaBazu.GodineStudija.Where(g=>g.Aktivna).ToList();
            cmbPredmeti.DisplayMember = "Naziv";
            cmbPredmeti.ValueMember = "Id";

        }

        private void UcitajOcjene()
        {
            var Ocjene = new List<int>
            {
                6,7,8,9,10
            };
            cmbOcjene.DataSource = Ocjene;
        }

        private void UcitajPredmete()
        {
            cmbPredmeti.DataSource = null;
            cmbPredmeti.DataSource = konekcijaNaBazu.Predmeti.ToList();
            cmbPredmeti.ValueMember = "Id";
            cmbPredmeti.DisplayMember = "Naziv";
        }

        private void UcitajPolozenePredmete()
        {
            try
            {
                dgvPolozeniPredmeti.DataSource = null;
                dgvPolozeniPredmeti.DataSource = konekcijaNaBazu.KorisniciPredmeti.Where(k=>k.Korisnik.Id == korisnik.Id).ToList();
            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }


        private void btnDodajPolozeni_Click(object sender, EventArgs e)
        {
            var godina = cmbGodine.SelectedItem as GodineStudija;
            var predmet = cmbPredmeti.SelectedItem as Predmeti;
            var ocjena = int.Parse(cmbOcjene.SelectedItem.ToString());


            foreach (var item in korisnik.Uspjeh)
            {
                if (item.GodinaStudija != null)
                {
                    if (item.Predmet.Naziv == predmet.Naziv && godina.Id == item.GodinaStudija.Id)
                    {
                        err.SetError(btnDodajPolozeni, MboxHelper.OnemogucenoDodavanjePredmeta);
                        MessageBox.Show(MboxHelper.OnemogucenoDodavanjePredmeta);
                        return;
                    }
                }
            }

            try
            {
                konekcijaNaBazu.KorisniciPredmeti.Add(new KorisniciPredmeti()
                {
                    Korisnik = korisnik,
                    Predmet = predmet,
                    Ocjena = ocjena,
                    Datum = dtpDatumPolaganja.Text,
                    GodinaStudija = godina
                });
                konekcijaNaBazu.SaveChanges();
                
                UcitajPolozenePredmete();
            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }

        private void btnPrintajUvjerenje_Click(object sender, EventArgs e)
        {
            var godina = cmbGodine.SelectedItem as GodineStudija;
            var lista = DLWMS.DB.KorisniciPredmeti.Where(k => k.Korisnik.Id == korisnik.Id && godina.Id == k.GodinaStudija.Id).ToList();

            if (lista?.Count > 0)
            {
                frmIzvjestaj frmIzvjestaj = new frmIzvjestaj(korisnik, godina);
                frmIzvjestaj.Show();
            }
            else
                MessageBox.Show(MboxHelper.PraznaLista);
        }
    }
}
