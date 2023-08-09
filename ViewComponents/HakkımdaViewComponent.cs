using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.ViewComponents
{
    public class HakkımdaViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<string> bilgilerim = new List<string>();
            bilgilerim.Add("Tahiri");
            bilgilerim.Add("Web Developer");
            bilgilerim.Add("tahirifdn@gmail.com");
            return View(bilgilerim);
        }
    }
}
