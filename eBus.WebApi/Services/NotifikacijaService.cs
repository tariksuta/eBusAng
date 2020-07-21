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
    public class NotifikacijaService : BaseCRUDService<Model.Notifikacije, NotifikacijeSearchRequest, Database.Notifikacije, NotifikacijaUpsertRequest, NotifikacijaUpsertRequest>
    {
        public NotifikacijaService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Notifikacije> Get(NotifikacijeSearchRequest search)
        {
            var query = _context.Notifikacije.Include( x => x.Novost).AsQueryable();

            if(search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.Naslov))
                {
                    query = query.Where(l => l.Naslov.StartsWith(search.Naslov));
                }

                if (search.NovostId.HasValue)
                {
                    query = query.Where(l => l.NovostId == search.NovostId.Value);
                }
            }

            var lista = query.OrderByDescending(l => l.DatumSlanja).ToList();

            return _mapper.Map<List<Model.Notifikacije>>(lista);

        }
    }
}
