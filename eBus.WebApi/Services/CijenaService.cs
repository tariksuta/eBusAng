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
    public class CijenaService : BaseCRUDService<Model.Cijena, CijenaSearchRequest, Database.Cijena, CijenaUpsertRequest, CijenaUpsertRequest>
    {
        public CijenaService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Cijena> Get(CijenaSearchRequest search)
        {
            var query = _context.Cijena.Include(x => x.Kompanija).AsQueryable();

            if(search != null)
            {
                if (search.LinijaID.HasValue)
                {
                    query = query.Where(l => l.LinijaId == search.LinijaID.Value);
                }

                if (search.KompanijaID.HasValue)
                {
                    query = query.Where(l => l.KompanijaId == search.KompanijaID.Value);
                }
            }

            var lista = query.ToList();

            return _mapper.Map<List<Model.Cijena>>(lista);
        }
    }
}
