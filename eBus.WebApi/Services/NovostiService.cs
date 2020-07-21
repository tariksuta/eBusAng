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
    public class NovostiService : BaseCRUDService<Model.Novosti, NovostiSearchRequest, Database.Novosti, NovostiUpsertRequest, NovostiUpsertRequest>
    {
        public NovostiService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Novosti> Get(NovostiSearchRequest search)
        {
            var query = _context.Novosti.Include(x => x.Korisnik).AsQueryable();

            if(search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.Naslov))
                {
                    query = query.Where(l => l.Naslov.StartsWith(search.Naslov));
                }
                //search.DatumObjave = DateTime.Now;

                if (search.DatumObjave != null)
                {
                    query = query.Where(l => l.DatumObjave.Value.Date == search.DatumObjave.Value.Date);
                }
            }

            var lista = query.OrderByDescending(x => x.DatumObjave).ToList();

            return _mapper.Map<List<Model.Novosti>>(lista);
        }
    }
}
