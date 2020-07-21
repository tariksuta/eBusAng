using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model
{
    public class Putnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public byte[] Slika { get; set; }
        public string Email { get; set; }
        public DateTime? DatumRegistracije { get; set; }
        public DateTime? DatumRodjenja { get; set; }

        public string Podaci { get { return $"{Ime} {Prezime}"; } }

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }
}
