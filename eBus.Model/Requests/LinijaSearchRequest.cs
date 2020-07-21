using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class LinijaSearchRequest
    {

        public int? OdredisteId { get; set; }
        public int? PolazisteId { get; set; }

        public string NazivOdredista { get; set; }
        public string NazivPolazista { get; set; }

        public bool PoNazivu { get; set; }
        public DateTime Datum { get; set; }


    }
}
