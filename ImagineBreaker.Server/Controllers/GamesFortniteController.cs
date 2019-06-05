using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ImagineBreaker.Server.Controllers
{
    [Route("api/games/fortnite")]
    public class GamesFortniteController : Controller
    {
        [HttpGet("user")]
        public async Task<ActionResult<string>> Get([FromQuery(Name = "user")] string user)
        {
            return $"Hey {user}";
        }
    }
}