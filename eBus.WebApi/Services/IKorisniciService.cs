using eBus.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBus.WebApi.Services
{
    public interface IKorisniciService
    {
        List<Model.Korisnici> Get(KorisniciSearchRequest search);

        Model.Korisnici GetById(int id);

        Model.Korisnici Insert(KorisniciUpsertRequest request);

        Model.Korisnici Update(int id, KorisniciUpsertRequest request);
    }
}
