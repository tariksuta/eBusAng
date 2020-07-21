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
    public class PutnikService : BaseCRUDService<Model.Putnik, PutnikSearchRequest, Database.Putnik, PutnikUpsertRequest, PutnikUpsertRequest>
    {
        public PutnikService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Putnik> Get(PutnikSearchRequest search)
        {
            var query = _context.Putnik.AsQueryable();

            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Ime))
                {
                    query = query.Where(l => l.Ime.StartsWith(search.Ime));
                }

                if (!string.IsNullOrEmpty(search.Prezime))
                {
                    query = query.Where(l => l.Prezime.StartsWith(search.Prezime));
                }

                if (!string.IsNullOrWhiteSpace(search.KorisnickoIme))
                {
                    query = query.Where(l => l.KorisnickoIme == search.KorisnickoIme);
                }


            }
            var lista = query.ToList();


            return _mapper.Map<List<Model.Putnik>>(lista);
        }

        public override Model.Putnik Insert(PutnikUpsertRequest request)
        {
            var entiitet = _mapper.Map<Database.Putnik>(request);

            if (entiitet == null)
                throw new Exception("Putnik je prazan");

            if (request.Lozinka != request.PotvrdiLozinku)
            {
                throw new Exception("Lozinke se ne podudaraju");
            }

            entiitet.LozinkaSalt = Util.PasswordGenerator.GenerateSalt();
            entiitet.LozinkaHash = Util.PasswordGenerator.GenerateHash(request.Lozinka, entiitet.LozinkaSalt);

            _context.Putnik.Add(entiitet);
            _context.SaveChanges();

            return _mapper.Map<Model.Putnik>(entiitet);
        }

        public override Model.Putnik Update(int id, PutnikUpsertRequest request)
        {
            var entitet = _context.Putnik.FirstOrDefault(x => x.Id == id);

            _context.Attach(entitet);
            _context.Update(entitet);

            if (entitet == null)
                throw new Exception("Putnik je prazan");

            if(request.Lozinka != request.PotvrdiLozinku)
            {
                throw new Exception("Lozinke nisu iste");
            }

            entitet.LozinkaSalt = Util.PasswordGenerator.GenerateSalt();
            entitet.LozinkaHash = Util.PasswordGenerator.GenerateHash(request.Lozinka, entitet.LozinkaSalt);

            _mapper.Map(request, entitet);
            _context.SaveChanges();

            return _mapper.Map<Model.Putnik>(entitet);
        }
    }
}
