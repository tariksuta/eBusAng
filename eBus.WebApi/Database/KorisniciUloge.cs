using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class KorisniciUloge
    {
        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }
        public DateTime? DatumIzmjene { get; set; }

        public virtual Korisnici Korisnik { get; set; }
        public virtual Uloga Uloga { get; set; }
    }
}
