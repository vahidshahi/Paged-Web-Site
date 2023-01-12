using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTeam04.Controllers
{                                               // deze contoller dient om een mail naar de gebruiker sturen
                                                // gebruiiker = heeft zijn mail ingegeven op de Donneer.html pagina te sturen 
    [Route("api/[controller]")]
    [ApiController]
    public class DoneerMailController : ControllerBase
    {                           
        public ActionResult ContactPageByMail(MailSender mailSender)
        {

           mailSenders.OntwerpDoneerMail(mailSender);
           var jsonString = JsonConvert.SerializeObject("Je Bericht is verzonden ");
           return Ok(jsonString);


        }

    }
}
