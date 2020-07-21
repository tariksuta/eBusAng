using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class LinijaUpsertRequest
    {

        [Required]
        public string Naziv { get; set; }
        [Required]
        public int PolazisteId { get; set; }
        [Required]
        public int OdredisteId { get; set; }
        public int KorisnikId { get; set; }

       
    }
}
