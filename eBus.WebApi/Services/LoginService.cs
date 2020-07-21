using AutoMapper;
using eBus.Model;
using eBus.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBus.WebApi.Services
{
    public class LoginService : ILoginService
    {

        private readonly _170048Context _context;
        private readonly IMapper _mapper;

        public LoginService(_170048Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       

        public Model.Korisnici Authenticiraj(string username, string pass)
        {

            var user = _context.Korisnici.Include("KorisniciUloge.Uloga").FirstOrDefault(x => x.KorisnickoIme == username);

            if(user != null)
            {
                var newHash = Util.PasswordGenerator.GenerateHash(pass, user.LozinkaSalt);

                if(newHash == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Korisnici>(user);
                }
            }

            return null;
        }

        public Model.Korisnici AuthenticirajPutnika(string username, string pass)
        {
            var user = _context.Putnik.FirstOrDefault(x => x.KorisnickoIme == username);

            if(user != null)
            {
                var newHash = Util.PasswordGenerator.GenerateHash(pass, user.LozinkaSalt);

                if(newHash == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Korisnici>(user);
                }
            }

            return null;
        }
    }
}
