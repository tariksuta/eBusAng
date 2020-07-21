using AutoMapper;
using eBus.Model;
using eBus.Model.Requests;
using eBus.WebApi.Database;
using eBus.WebApi.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eBus.WebApi.Services
{
    public class KorisniciService : IKorisniciService
    {
        protected _170048Context _context;
        protected IMapper _mapper;

        public KorisniciService(_170048Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        

        public List<Model.Korisnici> Get(KorisniciSearchRequest search)
        {
            var query = _context.Korisnici.AsQueryable();

            if (search != null)
            {
                if (!string.IsNullOrWhiteSpace(search?.Ime))
                {
                    query = query.Where(l => l.Ime.StartsWith(search.Ime));
                }

                if (!string.IsNullOrWhiteSpace(search?.Prezime))
                {
                    query = query.Where(l => l.Prezime.StartsWith(search.Prezime));
                }

                if (!string.IsNullOrWhiteSpace(search?.KorisnickoIme))
                {
                    query = query.Where(l => l.KorisnickoIme.StartsWith(search.KorisnickoIme));
                }
            }

            var lista = query.ToList();
            return _mapper.Map<List<Model.Korisnici>>(lista);
        }

        public Model.Korisnici GetById(int id)
        {
            var entitet = _context.Korisnici.Find(id);

            if(entitet == null)
            {
                throw new UserException("Niije pronadjen korisnik!");
            }


            return _mapper.Map<Model.Korisnici>(entitet);
        }

        public  Model.Korisnici Insert(KorisniciUpsertRequest request)
        {
            var entitet = _mapper.Map<Database.Korisnici>(request);

            if (request.Lozinka != request.PotvrdiLozinku)
            {
                throw new UserException("Lozinke se ne podudaraju");
            }

            entitet.LozinkaSalt = Util.PasswordGenerator.GenerateSalt();
            entitet.LozinkaHash = Util.PasswordGenerator.GenerateHash(request.Lozinka, entitet.LozinkaSalt);

            _context.Korisnici.Add(entitet);

            _context.SaveChanges();

            foreach (var item in request.Uloge)
            {
                var korisniciUloga = new Database.KorisniciUloge();
                korisniciUloga.DatumIzmjene = DateTime.Now;
                korisniciUloga.KorisnikId = entitet.Id;
                korisniciUloga.UlogaId = item;
                _context.KorisniciUloge.Add(korisniciUloga);
            }

            _context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entitet);
        }

        public  Model.Korisnici Update(int id, KorisniciUpsertRequest request)
        {
            var entitet = _context.Korisnici.Find(id);

            if(entitet == null)
            {
                throw new UserException("Ne postoji korisnik");
            }

            _context.Korisnici.Attach(entitet);
            _context.Korisnici.Update(entitet);

            if (request.Lozinka != request.PotvrdiLozinku)
                throw new UserException("Lozinke se ne podudaraju");

            entitet.LozinkaSalt = Util.PasswordGenerator.GenerateSalt();
            entitet.LozinkaHash = Util.PasswordGenerator.GenerateHash(request.Lozinka, entitet.LozinkaSalt);

            _mapper.Map(request, entitet);
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entitet);
        }
    }
}
