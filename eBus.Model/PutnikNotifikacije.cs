using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model
{
    public class PutnikNotifikacije
    {

        public int Id { get; set; }
        public int NotifikacijaId { get; set; }
        public int PutnikId { get; set; }
        public bool Pregledana { get; set; }

        public virtual Notifikacije Notifikacija { get; set; }
        public virtual Putnik Putnik { get; set; }
    }
}
