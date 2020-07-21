using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model
{
    public class Ocjena
    {
        public int Id { get; set; }
        public int PutnikId { get; set; }
        public int KompanijaId { get; set; }
        public int OcjenaUsluge { get; set; }
        public string Komentar { get; set; }

        public virtual Kompanija Kompanija { get; set; }
        public virtual Putnik Putnik { get; set; }
    }
}
