using System;

namespace DLWMS.WinForms.Entiteti
{
    public class Poruke
    {
        public const string DobroDosli = "Dobro dosli";
        public const string KorisnickiNalogNijeAktivan = "Korisnicki nalog nije aktivan!";
        public const string ObaveznaVrijednost = "Obavezna vrijednost";
        public const string KorisnikNePostoji = "Ne postoji korisnik sa unijetim kredencijalima!";
        public const string KorisnikUspjesnoDodan = "Podaci o korisniku uspjesno dodani!";
        public const string StudentUspjesnoDodan = "Podaci o studentu uspjesno dodani!";
        public const string StudentPodaciUspjesnoModifikovani = "Podaci o studentu uspjesno modifikovani!";
        public const string PraznaLista = "Lista je prazna.";
        public const string IzlazIzPrograma = "Da li želite izaći iz programa?";
        public const string Pitanje = "Pitanje";
        public const string VrijednostNijeValidna = "Unesena vrijednost nije validna.";
        public const string BrisanjePotvrda = "Da li ste sigrni da zelite obrisati sve podatke o potvrdama?";
        public static void Greska(Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(
                ex.Message
                +Environment.NewLine
                +ex.InnerException?.Message);
        }


    }
}
