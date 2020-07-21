using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model
{
    public class Sjediste
    {
        public int Id { get; set; }
        public int Red { get; set; }
        public int Kolona { get; set; }
        public int? VoziloId { get; set; }

        public virtual Vozilo Vozilo { get; set; }

        public string Pozicija { get {  return $"{Vozilo} -> red : {Red} - kolona {Kolona}"; } }
        public string Mjesto { get { return $" red : {Red} - kolona {Kolona}"; } }

        public override string ToString()
        {
            return $"{Vozilo} -> red { Red} - kolona {Kolona}";
        }
    }
}
