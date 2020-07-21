using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class Cijena
    {
        public int Id { get; set; }
        public int LinijaId { get; set; }
        public decimal Iznos { get; set; }
        public float? Popust { get; set; }
        public int KompanijaId { get; set; }

        public virtual Kompanija Kompanija { get; set; }
        public virtual Linija Linija { get; set; }
    }
}
