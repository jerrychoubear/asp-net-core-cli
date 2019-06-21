using System.Threading.Tasks;
using asp_net_core_cli.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_core_cli.Controllers
{
    public class ValueController : Controller
    {
        private readonly ISample _sample;

        public ValueController(ISample sample)
        {
            _sample = sample;
        }

        public string Index()
        {
            return $"[ISample]\r\nId: {_sample.Id}\r\nHashCode: {_sample.GetHashCode()}\r\nType: {_sample.GetType()}";
        }

        public string Hello() => "Hello world";
    }
}