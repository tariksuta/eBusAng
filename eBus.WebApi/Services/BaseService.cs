using AutoMapper;
using eBus.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBus.WebApi.Services
{
    public class BaseService<TModel, TSearch,TDatabase> : IService<TModel, TSearch> where TDatabase : class
    {
        protected _170048Context _context;
        protected IMapper _mapper;

        public BaseService(_170048Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual List<TModel> Get(TSearch search)
        {
            var lista = _context.Set<TDatabase>().ToList();

            return _mapper.Map<List<TModel>>(lista);
        }

        public virtual TModel GetById(int id)
        {
            var entitet = _context.Set<TDatabase>().Find(id);

            return _mapper.Map<TModel>(entitet);
        }
    }
}
