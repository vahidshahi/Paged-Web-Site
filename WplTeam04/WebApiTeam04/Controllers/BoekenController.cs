using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiTeam04.Controllers
{
    [Route("api/[controller]")]            // deze controller diend om de boeken die in de Database zitten op te vragen
                                          // als ook  bestel- , expectedreturn- en return-date door middel van een join query
    [ApiController]
    public class BoekenController : ControllerBase
    {

        [HttpGet]
        public ActionResult GetBoeken()
        {
            string jsonResult;
            var dt = Boeken.GetBoekendt();
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }
        

    }
}
