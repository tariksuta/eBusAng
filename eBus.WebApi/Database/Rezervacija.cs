using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class Rezervacija
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
