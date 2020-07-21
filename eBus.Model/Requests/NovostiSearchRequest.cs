using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class NovostiSearchRequest
    {

        public string Naslov { get; set; }

        public DateTime? DatumObjave { get; set; }
    }
}
