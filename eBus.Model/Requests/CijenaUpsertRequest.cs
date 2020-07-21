using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class CijenaUpsertRequest
    {
       
        public int? LinijaId { get; set; }
        public decimal Iznos { get; set; }
        public float? Popust { get; set; }
        public int KompanijaId { get; set; }
    }
}
