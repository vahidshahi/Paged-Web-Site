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
// account aanmaken 
namespace WebApiTeam04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetKlanten()
        {
            string jsonResult;
            var dt = Klanten.GetKlantenDataTable();
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }

        [HttpPost]
        public ActionResult<Klant> InsertKlant(Klant klant)
        {
            string jsonResult;
            var b = Klanten.AddKlant(klant);
            var id = b.NewId;
            jsonResult = JsonConvert.SerializeObject(id);
            return Ok(jsonResult);

        }
       
       
    }
}
