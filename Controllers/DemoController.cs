using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class DemoController : Controller
    {
        // GET: DemoController
        public IActionResult Index()
        {
            ViewBag.Message = "Hello from the DemoController!";
            var products = GetProducts();

            return View(products);
        }
        public List<Product> GetProducts()
        {
            // forma de hacerlo mas corta y limpia, pero no es la mejor forma de hacerlo
            /*return  
            [
                new() { Id = 1, Name = "Product 1", Description = "Description for Product 1" },
                new() { Id = 2, Name = "Product 2", Description = "Description for Product 2" },
                new() { Id = 3, Name = "Product 3", Description = "Description for Product 3" }
            ];*/
            return new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Description = "Description for Product 1" },
                new Product { Id = 2, Name = "Product 2", Description = "Description for Product 2" },
                new Product { Id = 3, Name = "Product 3", Description = "Description for Product 3" }
            };
        }

    }

}
