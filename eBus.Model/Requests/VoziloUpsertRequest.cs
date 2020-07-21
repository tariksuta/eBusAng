using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class VoziloUpsertRequest
    {
        public string Proizvodjac { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Registracija { get; set; }
        [Required]
        
        public int? BrojSjedista { get; set; }
        public int? KompanijaId { get; set; }
    }
}
