﻿using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P8;
using cSharpIntroWinForms.Solution;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace cSharpIntroWinForms
{
    [Table("Korisnik")]
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public virtual Spolovi Spol { get; set; }
        public bool Admin { get; set; }
        public List<PolozeniPredmet> Polozeni { get; set; } = new List<PolozeniPredmet>();
        public virtual List<KorisniciPredmeti> Uspjeh { get; set; } = new List<KorisniciPredmeti>();
        public virtual List<KorisniciSlike> Slike { get; set; } = new List<KorisniciSlike>();
        public override string ToString()
        {
            return $"{Ime} {Prezime} ({KorisnickoIme})";
        }
    }
}
