using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class OcjenaUpsertRequest
    {
       
        public int PutnikId { get; set; }
        public int KompanijaId { get; set; }
        public int OcjenaUsluge { get; set; }
        public string Komentar { get; set; }

        
    }
}
