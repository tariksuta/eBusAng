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
    public class VoziloService : BaseCRUDService<Model.Vozilo, VoziloSearchRequest, Database.Vozilo, VoziloUpsertRequest, VoziloUpsertRequest>
    {
        public VoziloService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Vozilo> Get(VoziloSearchRequest search)
        {
            var query = _context.Vozilo.Include(l => l.Kompanija).AsQueryable();

            if(search != null)
            {
                if (search.KompanijaId.HasValue)
                {
                    query = query.Where(l => l.KompanijaId == search.KompanijaId.Value);
                }
            }

            var lista = query.ToList();

            return _mapper.Map<List<Model.Vozilo>>(lista);
        }
    }
}
