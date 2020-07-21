using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class Korisnici
    {
        public Korisnici()
        {
            KorisniciUloge = new HashSet<KorisniciUloge>();
            Linija = new HashSet<Linija>();
            Novosti = new HashSet<Novosti>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public byte[] Slika { get; set; }
        public string Email { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<KorisniciUloge> KorisniciUloge { get; set; }
        public virtual ICollection<Linija> Linija { get; set; }
        public virtual ICollection<Novosti> Novosti { get; set; }
    }
}
