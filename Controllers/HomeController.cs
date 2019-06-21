using Microsoft.AspNetCore.Mvc;

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
    }
}