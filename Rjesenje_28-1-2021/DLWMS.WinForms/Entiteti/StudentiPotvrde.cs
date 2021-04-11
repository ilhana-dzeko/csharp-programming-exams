using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DLWMS.WinForms.Entiteti
{
    [Table("StudentiPotvrde")]
    public class StudentiPotvrde
    {
        public int Id { get; set; }
        public virtual Student Student { get; set; }
        public DateTime Datum { get; set; }
        public string Svrha { get; set; }
        public bool Izdata { get; set; }

    }
}
