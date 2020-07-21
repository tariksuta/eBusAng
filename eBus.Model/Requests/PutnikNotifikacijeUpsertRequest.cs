using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class PutnikNotifikacijeUpsertRequest
    {

        public int NotifikacijaId { get; set; }
        public int PutnikId { get; set; }
        public bool Pregledana { get; set; }
    }
}
