using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class CijenaSearchRequest
    {
        public int? LinijaID { get; set; }

        public int? KompanijaID { get; set; }
    }
}
