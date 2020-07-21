using System;
using System.Collections.Generic;

namespace eBus.WebApi.Database
{
    public partial class Karta
    {
        public Karta()
        {
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int Id { get; set; }
        public string BrojKarte { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public int SjedisteId { get; set; }
        public int AngazujeId { get; set; }
        public TimeSpan VrijemePolaska { get; set; } //? ide za IB170048
        public TimeSpan VrijemeDolaska { get; set; } //?

        public virtual Angazuje Angazuje { get; set; }
        public virtual Sjediste Sjediste { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
