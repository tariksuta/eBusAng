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

    

    public class DrzavaController : BaseCRUDController<Model.Drzava, DrzavaSearchRequest, DrzavaUpsertRequest, DrzavaUpsertRequest>
    {
        public DrzavaController(ICRUDService<Drzava, DrzavaSearchRequest, DrzavaUpsertRequest, DrzavaUpsertRequest> service) : base(service)
        {
        }
    }
}