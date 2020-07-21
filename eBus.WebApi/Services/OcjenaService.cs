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
    public class OcjenaService : BaseCRUDService<Model.Ocjena, OcjenaSearchRequest, Database.Ocjena, OcjenaUpsertRequest, OcjenaUpsertRequest>
    {
        public OcjenaService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Ocjena> Get(OcjenaSearchRequest search)
        {
            var query = _context.Ocjena.Include(x => x.Putnik)
                                        .Include(l => l.Kompanija).AsQueryable();

            if(search != null)
            {
                if (search.KompanijaId.HasValue)
                {
                    query = query.Where(l => l.KompanijaId == search.KompanijaId.Value);
                }
            }

            var lista = query.ToList();

            return _mapper.Map<List<Model.Ocjena>>(lista);
        }

        public override Model.Ocjena Insert(OcjenaUpsertRequest request)
        {
            return base.Insert(request);
        }
    }
}
