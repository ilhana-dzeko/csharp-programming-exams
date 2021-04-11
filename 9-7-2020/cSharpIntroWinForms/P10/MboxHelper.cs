using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms.P10
{
    public class MboxHelper
    {
        public const string NemaFotografija = "Nema vise fotografija.";
        public const string DodajFotografiju = "Zelite li dodati fotografiju?";
        public const string Pitanje = "Question";
        public const string VrijednostNijeValidna = "Vrijednost koju ste unijeli nije validna.";
        public const string NemaPolozenih = "Korisnici nemaju niti jedan polozeni predmet.";

        const string greska = "Greška";
        public static void PrikaziGresku(Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n{ex.InnerException?.Message}", 
                greska,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
    
}
