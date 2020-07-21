using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model
{
    public class LinijaPodaci
    {

        public string OdredisteNaziv { get; set; }
        public string PolazisteNaziv { get; set; }

        public decimal Cijena { get; set; }

        public string Kompanija { get; set; }

        public int AngazujeID { get; set; }
        public int VoziloID { get; set; }

        public DateTime DatumPretrage { get; set; }

        public TimeSpan VrijemePolaska { get; set; }





    }
}
