using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class Sjediste
    {
        public Sjediste()
        {
            Karta = new HashSet<Karta>();
        }

        public int Id { get; set; }
        public int Red { get; set; }
        public int Kolona { get; set; }
        public int VoziloId { get; set; }

        public virtual Vozilo Vozilo { get; set; }
        public virtual ICollection<Karta> Karta { get; set; }
    }
}
