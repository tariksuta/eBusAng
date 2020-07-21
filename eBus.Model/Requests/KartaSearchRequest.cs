using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class KartaSearchRequest
    {

        public bool PoDatumu { get; set; }
        
        public DateTime? DatumIzdavanja { get; set; } 

        public bool PoVozilu { get; set; }
        public int Red { get; set; }
        public int Kolona { get; set; }
       

        public bool PoAngzuje { get; set; }
        public int AngazujeID { get; set; }

        public bool IzSjedista { get; set; }

        //------------------------------ zadnje dodano
        public bool PoVremenu { get; set; }
        public TimeSpan VrijemePolaska { get; set; }
    }
}
