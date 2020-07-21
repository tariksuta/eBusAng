using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class NovostiUpsertRequest
    {
        [Required]
        public string Naslov { get; set; }
        [Required]
        public string Sadrzaj { get; set; }
        public DateTime? DatumObjave { get; set; }
        [Required]
        public int KorisnikId { get; set; }
    }
}
