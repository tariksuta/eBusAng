using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class AngazujeUpsertRequest
    {

        [Required]
        public int VoziloId { get; set; }
        [Required]
        public int LinijaId { get; set; }
        [Required]
        public DateTime DatumAngazovanja { get; set; }
        [Required]
        public DateTime DatumIsteka { get; set; }

        
    }
}
