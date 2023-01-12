using ClassLibTeam04.Business;
using ClassLibTeam04.Data;
using ClassLibTeam04.Entities;
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
    public class ContactPageByMailController : ControllerBase
    {
                             // deze contoller dient om een mail te sturen naar (bedrijf)Paged vanaf de Contachtpagina.html 
        [HttpPost]
        public ActionResult ContactPageByMail(MailSender mailsender)
        {
            mailSenders.OntwerpSentMail(mailsender);
           
            var jsonString = JsonConvert.SerializeObject("Je Bericht is verzonden ");
            return Ok(jsonString);

       
        }
    }
}
