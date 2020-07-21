using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class KorisniciUpsertRequest
    {
        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }
        [Required]
        [MinLength(4)]
        public string KorisnickoIme { get; set; }
        [Required]
        public byte[] Slika { get; set; }
        [Required]
        public string Email { get; set; }
        public bool? Status { get; set; }

        [Required]
        [MinLength(4)]
        public string Lozinka { get; set; }
        [Required]
        [MinLength(4)]
        public string PotvrdiLozinku { get; set; }

        public List<int> Uloge { get; set; } = new List<int>();
    }
}
