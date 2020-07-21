using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class RezervacijaSearchRequest
    {

        public int? PutnikId { get; set; }

        public bool PoAngazmanu { get; set; }
        public int AngazmanId { get; set; }
    }
}
