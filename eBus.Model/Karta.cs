using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model
{
    public class Karta
    {
        public int Id { get; set; }
        public string BrojKarte { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public int SjedisteId { get; set; }
        public int AngazujeId { get; set; }

        public TimeSpan VrijemePolaska { get; set; } //? ZA IB170048
        public TimeSpan VrijemeDolaska { get; set; } //?

        public virtual Sjediste Sjediste { get; set; }
        public virtual Angazuje Angazuje { get; set; }

        public string ZaRezervaciju { get { return $"{ BrojKarte}-{Angazuje}-{Sjediste}"; } }

        public override string ToString()
        {
            return $"{BrojKarte} - {DatumIzdavanja.Date.ToString("dd.MM.yyyy")}";
        }
    }
}
