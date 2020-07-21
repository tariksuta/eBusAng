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
    public class LinijaService : BaseCRUDService<Model.Linija, LinijaSearchRequest, Database.Linija, LinijaUpsertRequest, LinijaUpsertRequest>
    {
        public LinijaService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Linija> Get(LinijaSearchRequest search)
        {
            var query = _context.Linija.Include(x => x.Polaziste)
                                        .Include(x => x.Odrediste)
                                        .Include(l => l.Korisnik).AsQueryable();

            if(search != null)
            {
                if (search.PoNazivu)
                {
                   
                        if (!string.IsNullOrWhiteSpace(search.NazivPolazista))
                        {
                            query = query.Where(l => l.Polaziste.Naziv.StartsWith(char.ToUpper(search.NazivPolazista[0])+ search.NazivPolazista.Substring(1)));
                        }

                        if (!string.IsNullOrWhiteSpace(search.NazivOdredista))
                        {
                            query = query.Where(l => l.Odrediste.Naziv.StartsWith(char.ToUpper(search.NazivOdredista[0]) + search.NazivOdredista.Substring(1)));
                        }

                    
                }
                else
                {
                    


                        if (search.PolazisteId.HasValue)
                        {
                            query = query.Where(l => l.PolazisteId == search.PolazisteId.Value);
                        }

                        if (search.OdredisteId.HasValue)
                        {
                            query = query.Where(l => l.OdredisteId == search.OdredisteId.Value);
                        }



                    
                }
            }
            

           

            var lista = query.ToList();

            return _mapper.Map<List<Model.Linija>>(lista);
        }
    }
}
