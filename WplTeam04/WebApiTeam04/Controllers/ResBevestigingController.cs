using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTeam04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResBevestigingController : ControllerBase
    {
        [HttpPost]
        public ActionResult BevestigReservatie(BestellingsNrMail bestellingsNrMail)
        {
            Klanten.ProductBevestigingsEmail(bestellingsNrMail);
            return Ok();
        }
    }
}
