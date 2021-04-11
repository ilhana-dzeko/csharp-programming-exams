using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P9;
using cSharpIntroWinForms.Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace cSharpIntroWinForms
{
    public partial class KorisniciAdmin : Form
    {

        KonekcijaNaBazu konekcijaNaBazu = DLWMS.DB;

        public KorisniciAdmin()
        {
            InitializeComponent();
            dgvKorisnici.AutoGenerateColumns = false;
        }

        private void KorisniciAdmin_Load(object sender, EventArgs e)
        {
            LoadData();
            UcitajSpolove();
        }

        private void UcitajSpolove()
        {
            cmbSpolovi.DataSource = DLWMS.DB.Spolovi.ToList();
            cmbSpolovi.DisplayMember = "Naziv";
            cmbSpolovi.ValueMember = "Id";
        }

        private void LoadData(List<Korisnik> korisnici = null)
        {
            try
            {
                List<Korisnik> rezultati = korisnici ?? konekcijaNaBazu.Korisnici.ToList();

                dgvKorisnici.DataSource = null;
                dgvKorisnici.DataSource = rezultati;

            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtriraj();
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            Filtriraj();
        }        
        private void cbAdministrator_CheckedChanged(object sender, EventArgs e)
        {
            Filtriraj();
        }
        private void Filtriraj()
        {
            var filter = txtPretraga.Text.ToLower();
            var spol = cmbSpolovi.SelectedItem as Spolovi;

            try
            {
                LoadData(DLWMS.DB.Korisnici.Where(korisnik =>
                (korisnik.Ime.ToLower().Contains(filter)
                || korisnik.Prezime.ToLower().Contains(filter)
                || string.IsNullOrEmpty(filter))
                    && cbAdministrator.Checked == korisnik.Admin
                    && (spol.Id == korisnik.Spol.Id || spol.Naziv == "<NOT SET>")).ToList());
            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }

        private void btnPrintajPolozene_Click(object sender, EventArgs e)
        {
            var polozeniPredmeti = new List<KorisniciPredmeti>();

            foreach (var item in (dgvKorisnici.DataSource as List<Korisnik>))
            {
                foreach (var predmet in item.Uspjeh)
                {
                    polozeniPredmeti.Add(predmet);
                }
            }

            if (polozeniPredmeti?.Count > 0)
            {
                frmIzvjestaj frmIzvjestaj = new frmIzvjestaj(polozeniPredmeti);
                frmIzvjestaj.ShowDialog();
            }
            else
                MessageBox.Show(MboxHelper.NemaPolozenih);
        }

        private void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var korisnik = dgvKorisnici.SelectedRows[0].DataBoundItem as Korisnik;
            
            if(dgvKorisnici.CurrentCell is DataGridViewButtonCell)
            {
                frmKorisnikSlikePregled frmKorisnikSlikePregled = new frmKorisnikSlikePregled(korisnik);
                frmKorisnikSlikePregled.ShowDialog();
            }
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(ShowResult);

            t1.Start();
        }

        private void ShowResult()
        {
            long broj;
            var isBroj = long.TryParse(txtSuma.Text, out broj);
            
            if (isBroj)
            {
                MessageBox.Show("Suma brojeva: " + Sumiraj(broj));
                
                Action action = new Action(() => txtSuma.Text = "");
                BeginInvoke(action);
            }
            else
            {
                MessageBox.Show(MboxHelper.VrijednostNijeValidna);
            }
        }

        private long Sumiraj(long n)
        {
            long suma = 0;
            for (int i = 1; i <= n; i++)
            {
                suma += i;
            }

            return suma;
        }
    }
}
