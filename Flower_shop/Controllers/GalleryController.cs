using Flower_shop.EfStuff;
using Flower_shop.EfStuff.DbModels;
using Flower_shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Controllers
{
    public class GalleryController : Controller
    {
        private WebDbContext _dbContext;

        public GalleryController(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Products()
        {
            var productsView = _dbContext.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Img = x.Img,
                Price = x.Price,
                Type = x.Type
            }).ToList();
            return View(productsView);
        }
        public IActionResult SingleProduct(string productUrl, string productName, string productPrice)
        {
            ProductViewModel productModel = new ProductViewModel
            {
                Name = productName,
                Img = productUrl,
                Price = productPrice
            };
            return View(productModel);
        }
        [HttpGet]
        public IActionResult ProductEdition()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProductEdition(string name, string price, string img, string type)
        {
            var productDb = new Product
            {
                Name = name,
                Img = img,
                Price = price,
                Type = type
            };

            _dbContext.Products.Add(productDb);
            _dbContext.SaveChanges();

            return View();
        }
    }
}
