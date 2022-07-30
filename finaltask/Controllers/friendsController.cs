using learn.core.DTO;
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
    public class friendsController : ControllerBase
    {
        private readonly Iaddfriend_service fservice;
        private readonly Igetfriends_service gservice;
        public friendsController(Iaddfriend_service fservice, Igetfriends_service gservice)
        {
            this.fservice = fservice;
            this.gservice = gservice;
        }

        [HttpPost]
        [Route("addfriend")]
        public ActionResult addfriend([FromBody]addfriend_dto addFirend) {

            return Ok(fservice.addfriend(addFirend));
        }

        [HttpGet]
        [Route("getfriendsbyid/{id}")]
        public ActionResult getfriends(int id)
        {
            
            return Ok(gservice.getfriens(id));
            
        }

    }
}
