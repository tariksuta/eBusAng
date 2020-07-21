using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class PutnikNotifikacije
    {
        public int Id { get; set; }
        public int NotifikacijaId { get; set; }
        public int PutnikId { get; set; }
        public bool Pregledana { get; set; }

        public virtual Notifikacije Notifikacija { get; set; }
        public virtual Putnik Putnik { get; set; }
    }
}
