using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model.Requests
{
    public class DrzavaUpsertRequest
    { 
        [Required]
        public string Naziv { get; set; }
    }
}
