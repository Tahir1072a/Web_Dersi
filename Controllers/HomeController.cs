using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //Requestleri karşılayan action metottur.
        public IActionResult Index()
        {
            return View();
        }
        [NonAction] // Bu özelliği alan metotlar dışarıdan gelen requestleri karşılayamazlar.
        public void X()
        {

        }
    }
}
