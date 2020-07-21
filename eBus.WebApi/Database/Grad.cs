using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class Grad
    {
        public Grad()
        {
            Kompanija = new HashSet<Kompanija>();
            LinijaOdrediste = new HashSet<Linija>();
            LinijaPolaziste = new HashSet<Linija>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int DrzavaId { get; set; }

        public virtual Drzava Drzava { get; set; }
        public virtual ICollection<Kompanija> Kompanija { get; set; }
        public virtual ICollection<Linija> LinijaOdrediste { get; set; }
        public virtual ICollection<Linija> LinijaPolaziste { get; set; }
    }
}
