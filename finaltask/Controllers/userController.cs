using learn.core.Data;
using learn.core.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace finaltask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly Iuser_apiservice uservice;
        public userController(Iuser_apiservice uservice)
        {
            this.uservice = uservice;
        }
        [HttpPost]
        public ActionResult user([FromBody]user_api user) {
            int c = 0;
            int c2 = 0;
            string line = String.Empty;
            using (StreamReader streamreader = new StreamReader("C:\\Users\\USER\\Desktop\\emp.txt"))
            {
                while ((line = streamreader.ReadLine()) != null)
                {
                    c++;
                }}
            string[] arr = new string[c];
            line = String.Empty;
            using (StreamReader streamreader = new StreamReader("C:\\Users\\USER\\Desktop\\emp.txt"))
            {
                while ((line = streamreader.ReadLine()) != null)
                {
                    arr[c2] = line;
                    c2++;
                }
            }
            Random rd = new Random();
            int a = 0;
            string str1 = " ";
            string str2 = " ";
            int t = 0;
            int rand_num = rd.Next(0, arr.Length);
            string test = arr[rand_num];
            for (int i = 0; i < arr[rand_num].Length; i++)
        {   a = arr[rand_num].IndexOf(' ');
                str1 = arr[rand_num].Substring(0, a);
                t = arr[rand_num].Length - a - 1;
                str2 = arr[rand_num].Substring(a + 1, t);
            }
            string[] city = { "amman", "zarqa", "irbid" };
            int rand = rd.Next(0, city.Length);
            user.fname = str1;
            user.lname = str2;
            user.email = str1 + str2 + "@gmail.com";
            user.address = city[rand];
            return Ok(uservice.createtuser(user));
            

        
        }
        [HttpGet]
        [Route("getweather/{id}")]
         public IActionResult getweather(int id) {

           
            var r = uservice.getadress(id);
            string addr = r.Select(x=>x.address).FirstOrDefault().ToString();
            return Redirect("http://api.weatherstack.com/current?access_key=59d154821ace07e1053b948c270bc57f&query="+addr);

        }
        [HttpGet]
        [Route("getalluser")]
        public ActionResult getalluser() {
            return Ok(uservice.getalluser());
        }
        [HttpGet]
        [Route("getcountcity")]
        public ActionResult getcountcity ()
        {
            return Ok(uservice.getcountcity());
        }
    }
}
