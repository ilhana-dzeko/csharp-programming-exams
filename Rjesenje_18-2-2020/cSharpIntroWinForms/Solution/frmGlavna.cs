using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P8;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace cSharpIntroWinForms.Solution
{
    public partial class frmGlavna : Form
    {
        public frmGlavna()
        {
            InitializeComponent();
        }

        private void btnGodineStudija_Click(object sender, EventArgs e)
        {
            frmGodinaStudija frmGodinaStudija = new frmGodinaStudija();
            frmGodinaStudija.Show();
        }

        private void btnPolozeniPredmeti_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            
            try
            {
                var index = rand.Next(0, DLWMS.DB.Korisnici.Count() - 1);

                KorisniciPolozeniPredmeti korisniciPolozeniPredmeti = new KorisniciPolozeniPredmeti(DLWMS.DB.Korisnici.ToList().ElementAt(index));
                korisniciPolozeniPredmeti.Show();

            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
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

        private long Sumiraj(long broj)
        {
            long suma = 0;
            for (int i = 1; i <= broj; i++)
            {
                suma += i;
            }

            return suma;
        }
    }
}
