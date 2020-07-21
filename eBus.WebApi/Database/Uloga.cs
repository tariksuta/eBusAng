using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class Uloga
    {
        public Uloga()
        {
            KorisniciUloge = new HashSet<KorisniciUloge>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<KorisniciUloge> KorisniciUloge { get; set; }
    }
}
