using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AMST4.Carousel.MVC.Context;
using AMST4.Carousel.MVC.Models;

namespace AMST4.Carousel.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDataContext _context;

        public ProductController(ApplicationDataContext context)
        {
            _context = context;
        }

        public IActionResult ProductList()
        {
            var product = _context.Product.ToList();
            return View(product);
        }


        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {

            product.Id = Guid.NewGuid();
            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }


    }
}
