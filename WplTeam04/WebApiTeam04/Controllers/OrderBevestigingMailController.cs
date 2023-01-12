using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiTeam04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderBevestigingMailController : ControllerBase
    {

        public ActionResult<BevestigingsEmail> SendBevestigingsMail(BevestigingsEmail bevestigingsEmail)
        {
            var result = Bestellingen.SendMail(bevestigingsEmail);
            string jsonString = JsonConvert.SerializeObject(result);
            return Ok(jsonString);
        }


    }
}
