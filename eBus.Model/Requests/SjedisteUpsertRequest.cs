using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class SjedisteUpsertRequest
    {
        public int Red { get; set; }
        public int Kolona { get; set; }
        public int? VoziloId { get; set; }
    }
}
