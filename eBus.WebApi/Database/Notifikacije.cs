using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class Notifikacije
    {
        public Notifikacije()
        {
            PutnikNotifikacije = new HashSet<PutnikNotifikacije>();
        }

        public int Id { get; set; }
        public string Naslov { get; set; }
        public DateTime? DatumSlanja { get; set; }
        public int? NovostId { get; set; }
        //public bool Procitano { get; set; }

        public virtual Novosti Novost { get; set; }
        public virtual ICollection<PutnikNotifikacije> PutnikNotifikacije { get; set; }
    }
}
