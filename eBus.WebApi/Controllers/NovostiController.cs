using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eBus.Model;
using eBus.Model.Requests;
using eBus.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBus.WebApi.Controllers
{

    [AllowAnonymous]

    public class NovostiController : BaseCRUDController<Model.Novosti, NovostiSearchRequest, NovostiUpsertRequest, NovostiUpsertRequest>
    {
        public NovostiController(ICRUDService<Novosti, NovostiSearchRequest, NovostiUpsertRequest, NovostiUpsertRequest> service) : base(service)
        {
        }
    }
}