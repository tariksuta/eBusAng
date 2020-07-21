using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class RezervacijaUpsertRequest
    {
        [Required]
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumIsteka { get; set; }
        public bool? Otkazana { get; set; }
        [Required]
        public int PutnikId { get; set; }
        [Required]
        public int KartaId { get; set; }
        public byte[] Qrcode { get; set; }

        // dodatak
        public decimal CijenaSaPopustom { get; set; }
        
    }
}
