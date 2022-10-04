using Flower_shop.EfStuff;
using Flower_shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Controllers
{
    public class TestController : Controller
    {
        private WebDbContext _dbContext;

        public TestController(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult TestDb()
        {
            var products = _dbContext.Products.ToList();

            List<ProductViewModel> productsView = products
                .Select(x => new ProductViewModel { 
                    Id = x.Id, 
                    Name = x.Name, 
                    Img = x.Img, 
                    Price = x.Price, 
                    Type = x.Type })
                .ToList();

            return View(productsView);
        }
    }
}
