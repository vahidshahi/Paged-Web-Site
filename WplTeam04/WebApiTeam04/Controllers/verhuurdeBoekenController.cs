using ClassLibTeam04.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTeam04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class verhuurdeBoekenController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetBoeken()
        {
            string jsonResult;
            var dt = Boeken.GetBoekenWithDates();
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }
    }
}
