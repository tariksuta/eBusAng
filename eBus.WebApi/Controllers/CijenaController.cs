using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using eBus.Model.Requests;
using eBus.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBus.WebApi.Controllers
{

    //[Authorize(Roles = "Uposlenik,Administrator")]

        [AllowAnonymous]

    public class CijenaController : BaseCRUDController<Model.Cijena, CijenaSearchRequest, CijenaUpsertRequest, CijenaUpsertRequest>
    {
        public CijenaController(ICRUDService<Model.Cijena, CijenaSearchRequest, CijenaUpsertRequest, CijenaUpsertRequest> service) : base(service)
        {
        }
    }
}