using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eBus.Model;
using eBus.Model.Requests;
using eBus.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBus.WebApi.Controllers
{
   
    [AllowAnonymous]
   
    public class NotifikacijeController : BaseCRUDController<Model.Notifikacije, NotifikacijeSearchRequest, NotifikacijaUpsertRequest, NotifikacijaUpsertRequest>
    {
        public NotifikacijeController(ICRUDService<Notifikacije, NotifikacijeSearchRequest, NotifikacijaUpsertRequest, NotifikacijaUpsertRequest> service) : base(service)
        {
        }
    }
}