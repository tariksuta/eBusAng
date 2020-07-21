using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class Vozilo
    {
        public Vozilo()
        {
            Angazuje = new HashSet<Angazuje>();
            Sjediste = new HashSet<Sjediste>();
        }

        public int Id { get; set; }
        public string Proizvodjac { get; set; }
        public string Model { get; set; }
        public string Registracija { get; set; }
        public int BrojSjedista { get; set; }
        public int KompanijaId { get; set; }

        public virtual Kompanija Kompanija { get; set; }
        public virtual ICollection<Angazuje> Angazuje { get; set; }
        public virtual ICollection<Sjediste> Sjediste { get; set; }
    }
}
