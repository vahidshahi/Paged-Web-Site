using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiTeam04.Controllers
{
    /// <summary>
    /// Deze controller dient om items op te slaan in de database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BestelItemsController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Item> BestelItems(Item item)
        {
            string jsonString;
            var result = Items.ItemsOpslaan(item);
            jsonString = JsonConvert.SerializeObject(result);
            return Ok(jsonString);
        }
    }
}
