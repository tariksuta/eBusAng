using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class Linija
    {
        public Linija()
        {
            Angazuje = new HashSet<Angazuje>();
            Cijena = new HashSet<Cijena>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int PolazisteId { get; set; }
        public int OdredisteId { get; set; }
        public int KorisnikId { get; set; }

        public virtual Korisnici Korisnik { get; set; }
        public virtual Grad Odrediste { get; set; }
        public virtual Grad Polaziste { get; set; }
        public virtual ICollection<Angazuje> Angazuje { get; set; }
        public virtual ICollection<Cijena> Cijena { get; set; }
    }
}
