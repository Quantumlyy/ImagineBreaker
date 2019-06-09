using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ImagineBreaker.Images.Generators.Effects.General;

namespace ImagineBreaker.Server.Controllers
{
    [Route("api/effect")]
    public class EffectController : Controller
    {
        [HttpGet("grayscale")]
        public async Task<ActionResult<string>> GetGrayscale([FromQuery(Name = "target")] string target)
        {
            var result = await GrayscaleEffect.Grayscale.ModifyAsync(target);
            return File(result, "image/png");
        }
        
        [HttpGet("invert")]
        public async Task<ActionResult<string>> GetInvert([FromQuery(Name = "target")] string target)
        {
            var result = await InvertEffect.Invert.ModifyAsync(target);
            return File(result, "image/png");
        }
        
        [HttpGet("brightness")]
        public async Task<ActionResult<string>> GetBrightness([FromQuery(Name = "target")] string target, [FromQuery(Name = "brightness")] int brightness = 100)
        {
            BrightnessEffect.Brightness.BrightnessValue = brightness;
            var result = await BrightnessEffect.Brightness.ModifyAsync(target);
            return File(result, "image/png");
        }
    }
}