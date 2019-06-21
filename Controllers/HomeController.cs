using Microsoft.AspNetCore.Mvc;

namespace asp_net_core_cli.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [Route("[action]")]
        public string Index()
        {
            return "This is Home/Index";
        }
        [Route("[action]")]
        public string About()
        {
            return "This is Home/About";
        }
    }
}