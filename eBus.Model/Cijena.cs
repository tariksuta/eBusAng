using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model
{
    public class Cijena
    {
        public int Id { get; set; }
        public int? LinijaId { get; set; }
        public decimal Iznos { get; set; }
        public float? Popust { get; set; }

        public int KompanijaId { get; set; }

        public virtual Kompanija Kompanija { get; set; }
    }
}
