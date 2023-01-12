using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace WebApiTeam04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase     // kijkt als wachtwoord en email in de database bestaan zo ja is de gebruiker ingelogd  
    {
        [HttpPost]
        public ActionResult<Klant> EmailCheck(Klant klant)
        {
            string jsonResult;
            var result = Klanten.CheckEmail(klant);
            jsonResult = JsonConvert.SerializeObject(result);
            return Ok(jsonResult);
        }
    }
    
}
