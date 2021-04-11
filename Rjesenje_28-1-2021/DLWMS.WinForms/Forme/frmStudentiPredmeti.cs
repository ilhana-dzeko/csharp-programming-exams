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
    public partial class frmStudentiPredmeti : Form
    {
        Student student;

        KonekcijaNaBazu _baza = DLWMSdb.Baza;

        public frmStudentiPredmeti(Student student)
        {
            InitializeComponent();
            dgvPolozeniPredmeti.AutoGenerateColumns = false;
            this.student = student;
        }

        private void frmStudentiPredmeti_Load(object sender, EventArgs e)
        {
            try
            {
                UcitajPredmete();
                UcitajPolozenePredmete();
                UcitajUloge();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UcitajUloge()
        {
            checkedListBox1.DataSource = DLWMSdb.Baza.Uloge.ToList();
            checkedListBox1.ValueMember = "Id";
            checkedListBox1.DisplayMember = "Naziv";

            //var uloge = checkedListBox1.Items.Cast<Uloga>().ToList();

            //for (int i = 0; i < uloge.Count; i++)
            //{
            //    if (student.Uloge.Contains(uloge[i]))
            //        checkedListBox1.SetItemChecked(i, true);
            //}

            OznaciUlogeStudenta(checkedListBox1.Items.Cast<Uloga>().ToList());
        }

        private void OznaciUlogeStudenta(List<Uloga> list)
        {
            for (int i=0;i<list.Count;i++)
            {
                if (student.Uloge.Where(u => u.Id == list[i].Id).Count() > 0)
                    checkedListBox1.SetItemChecked(i, true);
            }
        }


        private void UcitajPolozenePredmete()
        {
            dgvPolozeniPredmeti.DataSource = null;
            dgvPolozeniPredmeti.DataSource = _baza.StudentiPredmeti.Where(x => x.Student.Id == student.Id).ToList();            
        }

        private void UcitajPredmete()
        {
            cmbPredmeti.DataSource = _baza.Predmet.ToList();
            cmbPredmeti.DisplayMember = "Naziv";
            cmbPredmeti.ValueMember = "Id";
        }

        private void btnDodajPolozeni_Click(object sender, EventArgs e)
        {
            //TODO: Na svim lokacijama na kojima je potrebno, dodati odgovarajucu obradu izuzetaka
            if (ValidanUnos())
            {

                _baza.StudentiPredmeti.Add(new StudentiPredmeti()
                {                    
                    Datum = dtpDatumPolaganja.Value,
                    Ocjena = int.Parse(cmbOcjene.Text),
                    Predmet = cmbPredmeti.SelectedItem as Predmet,
                    Student = student
                });
                _baza.SaveChanges();              
                UcitajPolozenePredmete();
                OnemoguciDodavanje();
                UcitajStatistiku();
            }
        }

        private void UcitajStatistiku()
        {
            //TODO: Korigovati na nacin da se podaci preuzimaju iz baze
            //TODO: Neke od podataka iskazati u procentima
            var brojZapisa = student.PolozeniPredmeti.Count;
            lblBrojZapisa.Text = $"Broj zapisa {brojZapisa}";
            if (brojZapisa > 0)
                lblProsjek.Text = $"Prosjecna ocjena {student.PolozeniPredmeti.Average(x => x.Ocjena)}";
        }

        private bool ValidanUnos()
        {
            return
               Validator.ValidirajKontrolu(cmbPredmeti, err, Poruke.ObaveznaVrijednost) &&
               Validator.ValidirajKontrolu(cmbOcjene, err, Poruke.ObaveznaVrijednost);
               
        }

        private void cmbPredmeti_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnemoguciDodavanje();
        }

        private void OnemoguciDodavanje()
        {
            var odabraniPredmet = cmbPredmeti.SelectedItem as Predmet;
            var postoji = student.PolozeniPredmeti.Where(polozeni => polozeni.Predmet.Id == odabraniPredmet.Id).Count() > 0;
            btnDodajPolozeni.Enabled = !postoji;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                student.Uloge.Add(_baza.Uloge.Find(2));
                _baza.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmIzvjestaji frmIzvjestaji = new frmIzvjestaji(DLWMSdb.Baza.StudentiPredmeti.Where(s => s.Student.Id == student.Id).ToList());
            frmIzvjestaji.Show();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class dtoStudentPrint
    {
        public string Indeks { get; set; }
        public string ImePrezime { get; set; }
        public List<StudentiPredmeti> Polozeni { get; set; }

    }
}
