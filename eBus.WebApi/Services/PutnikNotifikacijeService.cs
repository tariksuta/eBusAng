using AutoMapper;
using eBus.Model.Requests;
using eBus.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBus.WebApi.Services
{
    public class PutnikNotifikacijeService : BaseCRUDService<Model.PutnikNotifikacije, PutnikNotifikacijeSearchRequest, Database.PutnikNotifikacije, PutnikNotifikacijeUpsertRequest, PutnikNotifikacijeUpsertRequest>
    {
        public PutnikNotifikacijeService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.PutnikNotifikacije> Get(PutnikNotifikacijeSearchRequest search)
        {
            var query = _context.PutnikNotifikacije.Include(x => x.Putnik).Include(l => l.Notifikacija).AsQueryable();

            if(search != null)
            {
                if (search.PutnikId.HasValue)
                {
                    query = query.Where(l => l.PutnikId == search.PutnikId.Value);
                }

                if (search.NotifikacijaId.HasValue)
                {
                    query = query.Where(l => l.NotifikacijaId == search.NotifikacijaId.Value);
                }
                
            }

            var lista = query.ToList();

            return _mapper.Map<List<Model.PutnikNotifikacije>>(lista);
        }
    }
}
