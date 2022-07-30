using learn.core.Data;
using learn.core.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finaltask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class postController : ControllerBase
    {
        private readonly Ipost_apiservice pservice;
        public postController(Ipost_apiservice pservice)
        {
            this.pservice = pservice;
        }

        [HttpPost]
        public ActionResult createpost([FromBody]post_api p)
        {
            return Ok(pservice.createpost(p));
        }
        [HttpGet]
        public ActionResult getpost() {
            return Ok(pservice.getpost());
        }
    }
}
