using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class PutnikUpsertRequest
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string KorisnickoIme { get; set; }

        [Required(ErrorMessage ="Slika je potrebna")]
        public byte[] Slika { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime? DatumRegistracije { get; set; }
        public DateTime? DatumRodjenja { get; set; }

        [Required]
        public string Lozinka { get; set; }

        [Required]
        public string PotvrdiLozinku { get; set; }

    }
}
