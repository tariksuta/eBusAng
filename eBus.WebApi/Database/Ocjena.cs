using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class Ocjena
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
