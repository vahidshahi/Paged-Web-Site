using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiTeam04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturatieController : ControllerBase
    {
        public ActionResult<Facturatie> FacutuurOpslaan(Facturatie factuur)
        {
            string jsonString;
            var result = Facturaties.FactuurGegevens(factuur);
            int facutuurNr = result.FactuurNr;
            jsonString = JsonConvert.SerializeObject(facutuurNr);
            return Ok(jsonString);
        }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class FactuurGegevensController : ControllerBase
    {
        public ActionResult<Facturatie> Facutuur(Facturatie factuur)
        {
            string jsonString;
            var result = Facturaties.FactuurKrijgen(factuur);
            jsonString = JsonConvert.SerializeObject(result);
            return Ok(jsonString);
        }
    }
}
