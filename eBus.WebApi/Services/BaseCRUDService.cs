using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eBus.WebApi.Database;

namespace eBus.WebApi.Services
{
    public class BaseCRUDService<TModel, TSearch, TDatabase, TInsert, TUpdate> : BaseService<TModel, TSearch, TDatabase>, ICRUDService<TModel, TSearch, TInsert, TUpdate> where TDatabase : class
    {
        public BaseCRUDService(_170048Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual TModel Insert(TInsert request)
        {
            var entitet = _mapper.Map<TDatabase>(request);

            _context.Set<TDatabase>().Add(entitet);
            _context.SaveChanges();

            return _mapper.Map<TModel>(entitet);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entitet = _context.Set<TDatabase>().Find(id);

            _context.Set<TDatabase>().Attach(entitet);
            _context.Set<TDatabase>().Update(entitet);

            _mapper.Map(request, entitet);

            _context.SaveChanges();

            return _mapper.Map<TModel>(entitet);


        }
    }
}
