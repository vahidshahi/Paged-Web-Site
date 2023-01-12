using ClassLibTeam04.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ClassLibTeam04.Entities;

namespace WebApiTeam04.Controllers
{
                                         // deze controller word gebruikt om de klanten info in de databank up te date 
                                         // er komt een object binnen met een indicator 
                                         // deze indicator word gebruikt om te zien welke Query er moet worden uitgevoerd                 
    [Route("api/[controller]")]           
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public ActionResult UpdateDataIngelogdeGebruiker(Klant klant)
        {
            if (klant.indicator != "id") { Klanten.UpdateKlantenData(klant); }
            int id = klant.KlantId;
            string jsonResult;
            var dt = ClassLibTeam04.Business.Klanten.GetIngelogdeKlant(id);
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }

    }

}
