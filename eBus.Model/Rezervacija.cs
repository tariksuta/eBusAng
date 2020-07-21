using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumIsteka { get; set; }
        public bool? Otkazana { get; set; }
        public int PutnikId { get; set; }
        public int KartaId { get; set; }
        public byte[] Qrcode { get; set; }

        public virtual Karta Karta { get; set; }
        public virtual Putnik Putnik { get; set; }
    }
}
