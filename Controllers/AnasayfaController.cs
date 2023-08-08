using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AnasayfaController : Controller
    {
        public IActionResult Anasayfa()
        {
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
