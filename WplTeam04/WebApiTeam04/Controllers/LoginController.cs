using ClassLibTeam04.Business;
using ClassLibTeam04.Data.Framework;
using ClassLibTeam04.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace WebApiTeam04.Controllers // om inte loggen 
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {       

        [HttpGet]
        public ActionResult<Klant> SignInKlant(Klant klant)
        {
            string jsonResult;
            var dt = Klanten.GetKlantGegevens(klant);
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }

        [HttpPost]
        public ActionResult<Klant> Inloggen(Klant klant)
        
        {
            string jsonResult;
            
            var result = Klanten.GetKlantGegevens(klant);
            var rows = result.Rows;
            if(rows.Count > 0)
            {
                jsonResult = JsonConvert.SerializeObject(result);
            }
            else
            {
                jsonResult = JsonConvert.SerializeObject(0);


            }
            return Ok(jsonResult);

        }
      
    }
}
