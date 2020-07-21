using eBus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBus.WebApi.Services
{
    public interface IPreporukaService
    {
        List<LinijaPodaci> GetPreporuka(int id);
    }
}
