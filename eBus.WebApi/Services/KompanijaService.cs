using AutoMapper;
using eBus.Model;
using eBus.Model.Requests;
using eBus.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBus.WebApi.Services
{
    public class KompanijaService : BaseCRUDService<Model.Kompanija, KompanijaSearchRequest, Database.Kompanija, KompanijaUpsertRequest, KompanijaUpsertRequest>
    {
        public KompanijaService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Kompanija> Get(KompanijaSearchRequest search)
        {
            var query = _context.Kompanija.AsQueryable();

            if(search != null)
            {
                if (!string.IsNullOrWhiteSpace(search?.Naziv))
                {
                    query = query.Where(l => l.Naziv.StartsWith(search.Naziv));
                }


                if (search.GradId.HasValue) {
                    query = query.Where(l => l.GradId == search.GradId.Value);
                }
            }

            var lista = query.ToList();

            return _mapper.Map<List<Model.Kompanija>>(lista);
        }
    }
}
