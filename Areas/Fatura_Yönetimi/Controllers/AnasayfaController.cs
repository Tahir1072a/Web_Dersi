using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Fatura_Yönetimi.Controllers
{
    [Area("fatura_yönetimi")]
    public class AnasayfaController : Controller
    {
        public IActionResult Index()
        {
            var data = TempData["a"];
            return View();
        }
    }
}
