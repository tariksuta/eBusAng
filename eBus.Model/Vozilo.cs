using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model
{
    public class Vozilo
    {
        public int Id { get; set; }
        public string Proizvodjac { get; set; }
        public string Model { get; set; }
        public string Registracija { get; set; }
        public int? BrojSjedista { get; set; }
        public int? KompanijaId { get; set; }

        public virtual Kompanija Kompanija { get; set; }
        public string VoziloKompanija { get { return Model + " - " + Kompanija; } }



        public override string ToString()
        {
            return Model;
        }
    }
}
