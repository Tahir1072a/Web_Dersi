using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class AnasayfaController : Controller
    {
        ILog _log;
        public AnasayfaController(ILog log)
        {
            _log = log;
        }
        public IActionResult Anasayfa()
        {   
            _log.Log();
            return View();
        }
        public IActionResult HtmlBilgi()
        {
            return View();
        }
        public IActionResult Sayfa2()
        {
            return View();
        }

    }
}
