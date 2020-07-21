using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model
{
    public class Korisnici
    {

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public byte[] Slika { get; set; }
        public string Email { get; set; }
        public bool? Status { get; set; }

        

        public string OsobniPodaci { get { return $"{Ime} {Prezime}"; } }

        public ICollection<KorisniciUloge> KorisniciUloge { get; set; }
        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }
}
