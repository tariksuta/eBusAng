using AutoMapper;
using eBus.Model;
using eBus.Model.Requests;
using eBus.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBus.WebApi.Services
{
    public class AngazujeService : BaseCRUDService<Model.Angazuje, AngazujeSearchRequest, Database.Angazuje, AngazujeUpsertRequest, AngazujeUpsertRequest>
    {
        public AngazujeService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Angazuje> Get(AngazujeSearchRequest search)
        {
            var query = _context.Angazuje.Include(x=> x.Vozilo.Kompanija).Include(l => l.Linija).AsQueryable();


            if(search != null)
            {
                if (search.ZaLiniju)
                {
                    if (search.Datum != null)
                    {
                        query = query.Where(l => l.DatumAngazovanja.Date <= search.Datum.Date && l.DatumIsteka.Date >= search.Datum.Date);
                    }
                }
                else
                {
                   
                        if (search.LinijaId.HasValue)
                        {
                            query = query.Where(l => l.LinijaId == search.LinijaId.Value);
                        }

                        if (search.VoziloId.HasValue)
                        {
                            query = query.Where(l => l.VoziloId == search.VoziloId.Value);
                        }
                    
                }
            }

           
           

            var lista = query.ToList();

            return _mapper.Map<List<Model.Angazuje>>(lista);
        }

        public override Model.Angazuje GetById(int id)
        {

            var entitet = _context.Angazuje.Include(l => l.Vozilo).Include(k => k.Linija).FirstOrDefault(k => k.Id == id);

            return _mapper.Map<Model.Angazuje>(entitet);
           
        }
    }
}

