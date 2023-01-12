using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiTeam04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlantenController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Klant> GetKlantTable(Klant klant)
        {
            var dt = Klanten.GetKlantGegevens(klant);
            var jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }

    }
}
