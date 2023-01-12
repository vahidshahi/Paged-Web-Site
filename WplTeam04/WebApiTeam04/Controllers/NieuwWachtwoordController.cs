using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiTeam04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NieuwWachtwoordController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Klant> UpdateWachtwoord(Klant klant)
        {
            var result = Klanten.UpdateWachtwoord(klant);
            var jsonString = JsonConvert.SerializeObject(result);
            return Ok(jsonString);

        }
    }
}
