using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eBus.Model;
using eBus.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBus.WebApi.Controllers
{

    public class UlogaController : BaseController<Model.Uloga, object>
    {
        public UlogaController(IService<Uloga, object> service) : base(service)
        {
        }
    }
}