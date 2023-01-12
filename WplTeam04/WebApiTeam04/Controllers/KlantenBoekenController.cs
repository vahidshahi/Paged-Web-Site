using ClassLibTeam04.Entities;
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
    public class KlantenBoekenController : ControllerBase
    {
        [HttpPost]
        public ActionResult UpdateDataIngelogdeGebruiker(Klant klant)
        {
            string jsonResult;
            var dt = ClassLibTeam04.Business.Klanten.GetBoekenVanKlant(klant);
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }


    }
}
