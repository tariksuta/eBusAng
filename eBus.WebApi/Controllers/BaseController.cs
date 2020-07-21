using eBus.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBus.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TSearch> : ControllerBase where TSearch : class
    {
        protected IService<T, TSearch> _service;

        public BaseController(IService<T, TSearch> service)
        {
            _service = service;
        }


        [HttpGet]
        public List<T> Get([FromQuery]TSearch search = null)
        {
            return _service.Get(search);
        }

        [HttpGet("{id}")]
        public T Get(int id)
        {
            return _service.GetById(id);
        }
    }
}
