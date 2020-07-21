using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class KompanijaSearchRequest
    {
        public string Naziv { get; set; }

        public int? GradId { get; set; }
    }
}
