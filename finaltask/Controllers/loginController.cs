using learn.core.Data;
using learn.core.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace finaltask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly Iloginuser_apiservice loginservice;
        public loginController(Iloginuser_apiservice loginservice)
        {
            this.loginservice = loginservice;
        }
        [HttpPost]
        public IActionResult authen([FromBody] loginuser_api login)
        {
            var RESULT = loginservice.Authentication_jwt(login);

         

           

            if (RESULT == null)
            {
                return Unauthorized(); //401
            }
            else
            {


               
                return Ok(RESULT); //200
            }
        }
    }
}
