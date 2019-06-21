using asp_net_core_cli.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_core_cli.Controllers
{
    public class ValueController : Controller
    {
        private readonly ISampleTransient _transient;
        private readonly ISampleScoped _scoped;
        private readonly ISampleSingleton _singleton;

        public ValueController(ISampleTransient transient, ISampleScoped scoped, ISampleSingleton singleton)
        {
            _transient = transient;
            _scoped = scoped;
            _singleton = singleton;
        }

        public string Index()
        {
            return $"[ISampleTransient]\r\nId: {_transient.Id}\r\nHashCode: {_transient.GetHashCode()}\r\nType: {_transient.GetType()}\r\n\r\n" +
            $"[ISampleScoped]\r\nId: {_scoped.Id}\r\nHashCode: {_scoped.GetHashCode()}\r\nType: {_scoped.GetType()}\r\n\r\n" + 
            $"[ISampleSingleton]\r\nId: {_singleton.Id}\r\nHashCode: {_singleton.GetHashCode()}\r\nType: {_singleton.GetType()}\r\n";
        }

        public string Hello() => "Hello world";

        public IActionResult Page()
        {
            ViewBag._transient = _transient;
            ViewBag._scoped = _scoped;
            ViewBag._singleton = _singleton;

            return View();
        }
    }
}