using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace asp_net_core_cli.Controllers
{
    public class HomeController : Controller
    {
        public string Index(int id)
        {
            return $"This is Home/Index with id = {id}";
        }
        public string About()
        {
            return "This is Home/About";
        }
        public IActionResult BindBody([FromBody]BindBodyModel model) //ok
        {
            return Content($"version: {model.Version}");
        }
        public IActionResult BindRoute([FromRoute]string version) //ok
        {
            return Content($"version: {version}");
        }
        public IActionResult BindQuery([FromQuery]string version) //ok
        {
            return Content($"version: {version}");
        }
        public IActionResult BindForm([FromForm]string version) //ok
        {
            return Content($"version: {version}");
        }
        public IActionResult BindHeader([FromHeader]string version) //ok
        {
            return Content($"version: {version}");
        }
        public IActionResult BindServices([FromServices]ILogger<HomeController> logger)
        {
            logger.LogDebug("msg");
            return Content($"logger is null: {logger == null}.");
        }
    }
}