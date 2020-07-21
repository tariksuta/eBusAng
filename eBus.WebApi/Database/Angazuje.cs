using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class Angazuje
    {
        public Angazuje()
        {
            Karta = new HashSet<Karta>();
        }

        public int Id { get; set; }
        public int VoziloId { get; set; }
        public int LinijaId { get; set; }
        public DateTime DatumAngazovanja { get; set; }
        public DateTime DatumIsteka { get; set; }

        public virtual Linija Linija { get; set; }
        public virtual Vozilo Vozilo { get; set; }
        public virtual ICollection<Karta> Karta { get; set; }
    }
}
