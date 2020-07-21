using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class KartaUpsertRequest
    {

        [Required]
        public string BrojKarte { get; set; }
        [Required]
       [DataType(DataType.Date)]
        public DateTime DatumIzdavanja { get; set; }
        [Required]
        public int SjedisteId { get; set; }
        [Required]
        public int AngazujeId { get; set; }

       [DataType(DataType.Time)]
        public TimeSpan VrijemePolaska { get; set; } //? ZA IB170048
        [DataType(DataType.Time)]
        public TimeSpan VrijemeDolaska { get; set; } //?
    }
}
