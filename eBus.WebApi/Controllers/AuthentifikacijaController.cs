using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eBus.Model;
using eBus.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBus.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentifikacijaController : ControllerBase
    {

       
       
            private ILoginService _userService;

            public AuthentifikacijaController(ILoginService userService)
            {
                _userService = userService;
            }

           [AllowAnonymous]
            [HttpPost("authenticate")]
            public   IActionResult Authenticate([FromBody]Login model)
            {
                var user =  _userService.AuthenticirajPutnika(model.Username,model.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(user);
            }

            
       
    }
}