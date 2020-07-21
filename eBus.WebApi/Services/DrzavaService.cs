using AutoMapper;
using eBus.Model.Requests;
using eBus.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBus.WebApi.Services
{
    public class DrzavaService : BaseCRUDService<Model.Drzava, DrzavaSearchRequest, Database.Drzava, DrzavaUpsertRequest, DrzavaUpsertRequest>
    {
        public DrzavaService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Drzava> Get(DrzavaSearchRequest search)
        {
            var query = _context.Drzava.AsQueryable();

            if(search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.Naziv))
                {
                    query = query.Where(x => x.Naziv.StartsWith(search.Naziv));
                }
                
            }

            var lista = query.ToList();

            return _mapper.Map<List<Model.Drzava>>(lista);
        }
    }
}
