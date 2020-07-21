using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class Putnik
    {
        public Putnik()
        {
            Ocjena = new HashSet<Ocjena>();
            PutnikNotifikacije = new HashSet<PutnikNotifikacije>();
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public byte[] Slika { get; set; }
        public string Email { get; set; }
        public DateTime? DatumRegistracije { get; set; }
        //  public int? BrojTokena { get; set; } // nemam ovo u eBusTest

        public DateTime? DatumRodjenja { get; set; }

        public virtual ICollection<Ocjena> Ocjena { get; set; }
        public virtual ICollection<PutnikNotifikacije> PutnikNotifikacije { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
