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
    public class messageController : ControllerBase
    {
        private readonly Isendmessage_service mservice;
        public messageController(Isendmessage_service mservice)
        {
            this.mservice = mservice;
        }

        [HttpPost]
        public ActionResult send([FromBody]sendmessage_dto o) {
            return Ok(mservice.sendmessage(o));
        }
        [HttpGet]
        public ActionResult gettotlmessagecount() {

            return Ok(mservice.totalmessages());
                }

        [HttpGet]
        [Route("countrecivedmessages")]
        public ActionResult gettotalrecivedmessage() {
            return Ok(mservice.totalrecivedmessages());
        }

        [HttpPost]
        [Route("filtermessage")]
        public ActionResult filtermessage([FromBody]getdate getd)
        {

            return Ok(mservice.filtermessages(getd));
        }

        [HttpPost]
        [Route("searchmessage/{message}")]
        public ActionResult searchmessage(string message)
        {

            return Ok(mservice.searchmessage(message));
        }
    }
}
