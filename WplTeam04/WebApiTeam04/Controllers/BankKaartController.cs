using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiTeam04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankKaartController : ControllerBase
    {
        public ActionResult<Bankkaart> BankKaartOpslaan(Bankkaart bankkaart)
        {
            var result = BankKaartStatic.KaartGegevensOpslaan(bankkaart);
            string json = JsonConvert.SerializeObject(result);
            return Ok(json);
        }
    }
}
