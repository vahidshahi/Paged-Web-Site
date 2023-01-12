using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using ClassLibTeam04.Mail;
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
    public class MailController : ControllerBase
    {
        // kan een route aan meegeven met een parameter in de url
        // [Route("boek + add param")]


        //Test post eerst met postman, Kan je het breakpoint raken?
        // Nadat breakpoint geraakt is, parameter proberen door te geven
        [HttpPost]                                                
        public ActionResult ChangePasswordMessage(Klant klant)    // gaat een mail sturen naar de klant om een code te krijgen als een gebruike
                                                                  // zijn wachtwoord is vergeten 
        {
            int code = Klanten.CodeEmail(klant);
            string jsonCode = JsonConvert.SerializeObject(code);
            return Ok(code);
        }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class EmailBevestigingController : ControllerBase
    {
       
        [HttpPost]
        public ActionResult StuurEmaillKlant(Klant klant)   // Stuurt email naar de klant nadat de wachtwoord veranderd is 
        {
            var bericht = Klanten.BevestigingsEmail(klant);
            string jsonCode = JsonConvert.SerializeObject(bericht);
            return Ok(jsonCode);
        }

    }
}
