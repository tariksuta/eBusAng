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
    public class GradService : BaseCRUDService<Model.Grad, GradSearchRequest, Database.Grad, GradUpsertRequest, GradUpsertRequest>
    {
        public GradService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Grad> Get(GradSearchRequest search)
        {
            var query = _context.Grad.Include(l => l.Drzava).AsQueryable();
            
            if(search != null)
            {
                if (search.Drzavaid.HasValue)
                {
                    query = query.Where(l => l.DrzavaId == search.Drzavaid.Value);
                }
            }

            var lista = query.ToList();

            return _mapper.Map<List<Model.Grad>>(lista);
        }
    }
}
