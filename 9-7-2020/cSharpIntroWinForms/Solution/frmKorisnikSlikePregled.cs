using cSharpIntroWinForms.P10;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace cSharpIntroWinForms.Solution
{
    public partial class frmKorisnikSlikePregled : Form
    {
        private Korisnik korisnik;
        private int index = 0;
        
        public frmKorisnikSlikePregled()
        {
            InitializeComponent();
        }   

        private void UcitajSlike()
        {
            if (korisnik.Slike.Count != 0) 
            {
                pbSlika.Image = ImageHelper.FromByteToImage(korisnik.Slike.First().Slika);
            }
            else
            {
                if (MessageBox.Show(MboxHelper.DodajFotografiju,
                    MboxHelper.Pitanje,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)
                    == DialogResult.Yes)
                    DodajSliku();
                else
                    Close();
            }
        }

        private void DodajSliku()
        {
            if (ofdSlikaKorisnika.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbSlika.Image = Image.FromFile(ofdSlikaKorisnika.FileName);

                    var slika = new KorisniciSlike()
                    {
                        Korisnik = korisnik,
                        Slika = ImageHelper.FromImageToByte(pbSlika.Image)
                    };

                    korisnik.Slike.Add(slika);
                    DLWMS.DB.KorisniciSlike.Add(slika);
                    DLWMS.DB.SaveChanges();
                }
                catch (Exception ex)
                {
                    MboxHelper.PrikaziGresku(ex);
                }
            }
        }

        public frmKorisnikSlikePregled(Korisnik korisnik) : this()
        {
            this.korisnik = korisnik;
        }

        private void pbSlika_Click(object sender, EventArgs e)
        {
            DodajSliku();
        }

        private void frmKorisnikSlikePregled_Load(object sender, EventArgs e)
        {
            UcitajSlike();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                pbSlika.Image = ImageHelper.FromByteToImage(korisnik.Slike[index-1].Slika);
                index--;
            }
            else
            {
                if (MessageBox.Show(MboxHelper.DodajFotografiju,
                    MboxHelper.Pitanje,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)
                    == DialogResult.Yes)
                    DodajSliku();
            }
           
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if(index >= korisnik.Slike.Count - 1)
            {
                if (MessageBox.Show(MboxHelper.DodajFotografiju,
                    MboxHelper.Pitanje,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)
                    == DialogResult.Yes)
                    DodajSliku();
            }
            else
            {
                pbSlika.Image = ImageHelper.FromByteToImage(korisnik.Slike[index + 1].Slika);
                index++;
            }
        }
    }
}
