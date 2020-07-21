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
    public class KartaService : BaseCRUDService<Model.Karta, KartaSearchRequest, Database.Karta, KartaUpsertRequest, KartaUpsertRequest>
    {
        public KartaService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Karta> Get(KartaSearchRequest search)
        {
            var query = _context.Karta
                                        .Include(x => x.Sjediste.Vozilo.Kompanija)
                                            .Include(y => y.Angazuje.Linija)
                                        .Include(l => l.Rezervacija).AsQueryable();

            

            if (search != null)
            {
                if (search.PoAngzuje)
                {
                    query = query.Where(l => l.AngazujeId == search.AngazujeID);


                    if(search.PoDatumu)
                    {
                        query = query.Where(l => l.DatumIzdavanja.Date == search.DatumIzdavanja.Value.Date); 

                    }

                    if (search.PoVremenu)
                    {
                        query = query.Where(l => l.VrijemePolaska == search.VrijemePolaska);
                    }


                }
                else if (search.PoVozilu)
                {
                  
                    query = query.Where(l => l.Sjediste.Red == search.Red);
                    query = query.Where(l => l.Sjediste.Kolona == search.Kolona);
                    if (search.PoDatumu && search.IzSjedista)
                    {
                        query = query.Where(l => l.DatumIzdavanja.Date == search.DatumIzdavanja.Value.Date); // ovo sam morao dodati jer uveca datum iz nekog razloga
                                                                                                   //AddDays(-1) ukino sada jer datum pohranjujem bez vremena
                    }
                    else
                    {
                        query = query.Where(l => l.DatumIzdavanja.Date == search.DatumIzdavanja.Value.Date); // ovo sam morao dodati jer uveca datum iz nekog razloga

                    }

                    if (search.PoVremenu)
                    {
                        query = query.Where(l => l.VrijemePolaska == search.VrijemePolaska);
                    }
                }
                else
                {
                    if (search.DatumIzdavanja.HasValue)
                    {
                        query = query.Where(l => l.DatumIzdavanja.Date == search.DatumIzdavanja.Value.Date);
                    }

                    if (search.PoVremenu)
                    {
                        query = query.Where(l => l.VrijemePolaska == search.VrijemePolaska);
                    }

                }
               
            }

            var lista = query.ToList();

            return _mapper.Map<List<Model.Karta>>(lista);
        }

        public override Model.Karta GetById(int id)
        {
            var query = _context.Karta.Include(l => l.Angazuje).Include(t => t.Sjediste).Where(k => k.Id == id).FirstOrDefault();

            return _mapper.Map<Model.Karta>(query);
        }


    }
}
