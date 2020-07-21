using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class KompanijaUpsertRequest
    {
       
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string KontaktBroj { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Adresa { get; set; }
  
        public int? GradId { get; set; }
    }
}
