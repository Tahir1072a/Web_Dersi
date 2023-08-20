using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Yönetim_Paneli.Controllers
{
    [Area("yönetim_paneli")]
    public class AnasayfaController : Controller
    {
        public IActionResult Index()
        {
            TempData["a"] = 12;
            return RedirectToAction("Index","Anasayfa", new { area = "fatura_yönetimi" });
        }
    }
}
