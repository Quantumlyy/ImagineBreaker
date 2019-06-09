using ImagineBreaker.Text.Generators.Speech;
using Microsoft.AspNetCore.Mvc;

namespace ImagineBreaker.Server.Controllers
{
    [Route("api/text")]
    public class TextController : Controller
    {
        [HttpGet("mock")]
        public ActionResult<string> GetMock([FromQuery(Name = "text")] string text)
        {
            return MockString.Mock.Generate(text);
        }
    }
}