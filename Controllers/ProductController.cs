using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

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
                new Product {Id = 1 , Name  = "Tahiri", Quantity = 10},
                new Product {Id = 2 , Name  = "Ahmet", Quantity = 20},
                new Product {Id = 3 , Name  = "Sadık", Quantity = 1}
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
            Product product = new Product { Id = 1, Name = "Tahiri", Quantity = 19 };
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
            var headers = Request.Headers.ToList();
            //var routeValues = Request.RouteValues; 
            //var query = Request.QueryString;
            //var a = Request.Query["a"];
            var product = new Product();
            return View(product);
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            return View();
        }
    }
}
