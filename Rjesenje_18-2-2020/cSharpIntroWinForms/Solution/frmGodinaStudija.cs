using cSharpIntroWinForms.P10;
using System;
using System.Linq;
using System.Windows.Forms;

namespace cSharpIntroWinForms.Solution
{
    public partial class frmGodinaStudija : Form
    {
        GodineStudija godinaStudija = new GodineStudija();
        
        public frmGodinaStudija()
        {
            InitializeComponent();
            dgvGodineStudija.AutoGenerateColumns = false;
        }

        private void frmGodinaStudija_Load(object sender, EventArgs e)
        {
            UcitajGodineStudija();
        }

        private void UcitajGodineStudija()
        {
            try
            {
                dgvGodineStudija.DataSource = null;
                dgvGodineStudija.DataSource = DLWMS.DB.GodineStudija.ToList();
            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                err.SetError(txtNaziv,MboxHelper.ObaveznoPolje);
                return;
            }

            if (godinaStudija == null)  
            {
                foreach (var item in DLWMS.DB.GodineStudija)
                {
                    if (item.Naziv == txtNaziv.Text)
                    {
                        err.SetError(txtNaziv, MboxHelper.NedozvoljenoDupliciranje);
                        return;
                    }
                }

                try
                {
                    DLWMS.DB.GodineStudija.Add(
                        new GodineStudija()
                        {
                            Naziv = txtNaziv.Text,
                            Aktivna = cbAktivna.Checked
                        });
                    DLWMS.DB.SaveChanges();
                    
                    UcitajGodineStudija();
                }
                catch (Exception ex)
                {

                    MboxHelper.PrikaziGresku(ex);
                }
            }
            else
            {
                foreach (var item in DLWMS.DB.GodineStudija)
                {
                    if (item.Id == godinaStudija.Id)
                    {
                        item.Naziv = txtNaziv.Text;
                        item.Aktivna = cbAktivna.Checked;

                        DLWMS.DB.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        DLWMS.DB.SaveChanges();
                    }
                }

                godinaStudija = null;

                UcitajGodineStudija();
            }
        }

        private void dgvGodineStudija_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                godinaStudija = dgvGodineStudija.SelectedRows[0].DataBoundItem as GodineStudija;

                txtNaziv.Text = godinaStudija.Naziv;
                cbAktivna.Checked = godinaStudija.Aktivna;
            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }
    }
}
