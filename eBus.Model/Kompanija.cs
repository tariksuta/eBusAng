using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model
{
    public class Kompanija
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string KontaktBroj { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public int? GradId { get; set; }
        public string LokacijaSlike { get; set; }


        public string NazivGrada { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
