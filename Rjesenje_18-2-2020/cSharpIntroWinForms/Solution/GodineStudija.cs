using System.ComponentModel.DataAnnotations.Schema;

namespace cSharpIntroWinForms.Solution
{
    public class GodineStudija
    {
        public int Id{ get; set; }
        public string Naziv { get; set; }
        public bool Aktivna{ get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
