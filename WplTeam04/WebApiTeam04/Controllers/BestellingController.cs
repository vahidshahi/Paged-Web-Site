using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiTeam04.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class BestellingController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Bestelling> Bestelling(Bestelling bestel)
            {
            string jsonString;
            var result = Bestellingen.BestellingPlaatsen(bestel);
            int bestellingNr = result.BestellingNr;
            jsonString = JsonConvert.SerializeObject(bestellingNr);
            return Ok(jsonString);
        }
    }

 
}
