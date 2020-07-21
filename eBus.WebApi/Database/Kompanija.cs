using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class Kompanija
    {
        public Kompanija()
        {
            Cijena = new HashSet<Cijena>();
            Ocjena = new HashSet<Ocjena>();
            Vozilo = new HashSet<Vozilo>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string KontaktBroj { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public int? GradId { get; set; }
        public string LokacijaSlike { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual ICollection<Cijena> Cijena { get; set; }
        public virtual ICollection<Ocjena> Ocjena { get; set; }
        public virtual ICollection<Vozilo> Vozilo { get; set; }
    }
}
