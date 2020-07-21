using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model
{
    public class Angazuje
    {
        public int Id { get; set; }
        public int VoziloId { get; set; }
        public int LinijaId { get; set; }
        public DateTime DatumAngazovanja { get; set; }
        public DateTime DatumIsteka { get; set; }

     

        public string PodaciAngazovani { get { return Linija + " " + Vozilo + " OD " + DatumAngazovanja.ToString("dd.MM.") +" DO" + DatumIsteka.ToString("dd.MM."); } }

        public virtual Vozilo Vozilo { get; set; }
        public virtual Linija Linija { get; set; }

        public DateTime DatumA { get { return DatumAngazovanja.Date; } }

        public override string ToString()
        {
            return Linija + " " + Vozilo +" - "+ DatumAngazovanja.ToString("dd.MM.yyyy");
        }
    }
}
