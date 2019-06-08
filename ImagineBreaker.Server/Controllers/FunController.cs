using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ImagineBreaker.Images.Generators.Images.Fun;

namespace ImagineBreaker.Server.Controllers
{
    [Route("api/fun")]
    public class FunController : Controller
    {
        [HttpGet("slap")]
        public async Task<ActionResult<string>> Get([FromQuery(Name = "target")] string target, [FromQuery(Name = "invoker")] string invoker)
        {
            var result = await Slap.GenerateAsync(target, invoker); 
            return File(result, "image/png");
        }
    }
}