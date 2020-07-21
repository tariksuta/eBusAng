﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBus.Model
{
    public class Notifikacije
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public DateTime? DatumSlanja { get; set; }
        public int? NovostId { get; set; }
        public bool Procitano { get; set; }

        public virtual Novosti Novost { get; set; }
    }
}
