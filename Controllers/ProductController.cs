using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        #region  Json Result

        //public JsonResult GetProducts()
        //{
        //    JsonResult result = Json(new Product() { Id = 12 });
        //    return result;
        //}

        #endregion
        public IActionResult GetProducts()
        {
            //Veri üretilir.
            return View(); // => actiona ait view(.cshtml) dosyasını çağırır. 
        }
        #region ContentResult

        //public ContentResult GetProducts()
        //{
        //    ContentResult contentResult = Content("Gizli bir mesaj");
        //    return contentResult;
        //}

        #endregion

        public IActionResult Get()
        {
            var products = new List<Product>
            {
                new Product {Email = "" , Name  = "Tahiri", Quantity = 10},
                new Product {Email = "" , Name  = "Ahmet", Quantity = 20},
                new Product {Email = "" , Name  = "Sadık", Quantity = 1}
            };
            #region Model Bazlı Veri Gönderme
            //return View(products);
            #endregion
            #region ViewBag
            ViewBag.Products = products;
            #endregion
            #region ViewData
            ViewData["products"] = products;
            #endregion
            #region TempData
            TempData["products"] = products;
            #endregion
            return View();
        }
        public IActionResult GetTupple()
        {
            Product product = new Product { Email = "", Name = "Tahiri", Quantity = 19 };
            User user = new User { Id = 2 };
            //UserProduct userProduct = new();
            //userProduct.Product = product;
            //userProduct.User = user;
            //return View(userProduct);   

            var tuple = (product, user);
            return View(tuple);
             
        }
        public IActionResult CreateProduct()
        {
            //var headers = Request.Headers.ToList();
            //var routeValues = Request.RouteValues; 
            //var query = Request.QueryString;
            //var a = Request.Query["a"];
            //Tuple olarak nesene yakalama
            //var tuple = (new Product(),new User());
            return View();
        }
        //[HttpPost]
        //public IActionResult CreateProduct([Bind(Prefix ="Item1")]Product product,[Bind(Prefix ="Item2")]User user)
        //{
        //    return View();
        //}
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            //Kötü kod
            //if(!string.IsNullOrEmpty(product.Name) && product.Name.Length <= 100)
            //{
            //    //Veri tabanı işlemleri
            //    return View();
            //}

            //ModelState: Mvc de bir type'ın annotationslarının durumunu kontrol eden ve geriye sonuç dönen bir property.
            if (ModelState.IsValid) //Doğrulama yapıldıysa...
            {
                //Veri tabanı işlemleri
                return View();
            }
            else
            {
                //Loglama işlemleri ve kullanıcı bilgilendirmesi...
            }
            var messages = ModelState.ToList();
            return View(product);
        }
    }
}
