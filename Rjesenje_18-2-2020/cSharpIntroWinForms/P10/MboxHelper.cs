using System;
using System.Windows.Forms;

namespace cSharpIntroWinForms.P10
{
    public class MboxHelper
    {
        public const string VrijednostNijeValidna = "Vrijednost koju ste unijeli nije validna.";
        public const string NedozvoljenoDupliciranje = "Dupliciranje nije dozvoljeno.";
        public const string ObaveznoPolje = "Obavezno polje.";
        public const string OnemogucenoDodavanjePredmeta = "Onemoguceno dodavanje istoimenih predmeta na istoj godini studija.";
        public const string PraznaLista = "Lista je prazna.";

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
