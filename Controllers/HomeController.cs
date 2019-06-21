using Microsoft.AspNetCore.Mvc;

namespace asp_net_core_cli.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "This is Home/Index";
        }
        public string About()
        {
            return "This is Home/About";
        }
    }
}