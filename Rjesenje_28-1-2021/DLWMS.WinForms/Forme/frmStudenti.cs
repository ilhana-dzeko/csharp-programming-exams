using DLWMS.WinForms.Entiteti;
using DLWMS.WinForms.Helpers;
using DLWMS.WinForms.Izvjestaji;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DLWMS.WinForms.Forme
{
    public partial class frmStudenti : Form
    {
        KonekcijaNaBazu _baza = DLWMSdb.Baza; 

        public frmStudenti()
        {
            InitializeComponent();
            dgvStudenti.AutoGenerateColumns = false;
        }

        private void frmStudenti_Load(object sender, EventArgs e)
        {
            UcitajPodatkeOStudentima();
            UcitajAktivnosti();
            UcitajGodine();
        }

        private void UcitajGodine()
        {
            cmbGodine.DataSource = new List<string>() { "Sve", "1", "2", "3" };
        }

        private void UcitajAktivnosti()
        {
            cmbAktivnosti.DataSource = new List<string>() { "Svi", "Aktivni", "Neaktivni" };
        }

        
        private void UcitajPodatkeOStudentima(List<Student> studenti = null)
        {
            try
            {
                dgvStudenti.DataSource = null;
                dgvStudenti.DataSource = studenti ?? _baza.Studenti.ToList();

                IzracunajProsjek(dgvStudenti.DataSource as List<Student>);
            }
            catch (Exception ex)
            {
                Poruke.Greska(ex);
            }
        }

        private void IzracunajProsjek(List<Student> list)
        {
            int brojac = 0;
            double prosjek = 0;
           
            foreach (var item in list)
            {
                var polozeniPredmeti = DLWMSdb.Baza.StudentiPredmeti.Where(s => s.Student.Id == item.Id).ToList();

                foreach (var predmet in polozeniPredmeti)
                {
                    brojac++;
                    prosjek += predmet.Ocjena;
                }
                
            }

            if (brojac > 0)
                lblProsjek.Text = $"{Math.Round((prosjek / brojac), 2)}";
            else
                lblProsjek.Text = "0"; 
                
            lblBrStd.Text = $"{list.Count}";
        }

        private void PrikaziFormu(Form form)
        {
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void dgvStudenti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var student = dgvStudenti.SelectedRows[0].DataBoundItem as Student;
            Form form = null;
            if (student != null)
            {
                if (e.ColumnIndex == 6) 
                    form = new frmStudentiPredmeti(student);
                else
                    form = new frmNoviStudent(student);
                PrikaziFormu(form);

                UcitajPodatkeOStudentima();
            }
        }
        
        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            Filtriraj();
        }

        private void Filtriraj()
        {
            if (string.IsNullOrEmpty(txtPretraga.Text))
            {
                err.SetError(txtPretraga, Poruke.ObaveznaVrijednost);
                return;
            }

            var filter = txtPretraga.Text.ToLower();
            var godina = cmbGodine.Text;

            UcitajPodatkeOStudentima(_baza.Studenti.Where(s 
                => (s.Ime.ToLower().Contains(filter) || s.Prezime.ToLower().Contains(filter))
                  && ((s.Aktivan && cmbAktivnosti.Text=="Aktivni") || (!s.Aktivan && cmbAktivnosti.Text=="Neaktivni") || cmbAktivnosti.Text=="Svi") 
                  && (s.GodinaStudija.ToString() == godina || godina=="Sve")
                  ).ToList());

        }

        private void cmbAktivnosti_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtriraj();
        }

        private void cmbGodine_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtriraj();
        }

        private void btnPrintaj_Click(object sender, EventArgs e)
        {
            var studenti = dgvStudenti.DataSource as List<Student>;
            if (studenti?.Count > 0)
            {
                frmIzvjestaji frmIzvjestaji = new frmIzvjestaji(studenti);
                frmIzvjestaji.Show();
            }
            else
                MessageBox.Show(Poruke.PraznaLista);
        }
    }
}
