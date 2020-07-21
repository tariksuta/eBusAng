using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class PutnikNotifikacijeSearchRequest
    {
        public int? PutnikId { get; set; }
        public int? NotifikacijaId { get; set; }
    }
}
