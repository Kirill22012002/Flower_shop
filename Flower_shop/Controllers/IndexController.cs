using Flower_shop.EfStuff;
using Flower_shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Controllers
{
    public class IndexController : Controller
    {
        private WebDbContext _dbContext;
        public IndexController(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var productsView = _dbContext.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Type = x.Type,
            }).Take(4).ToList();

            return View(productsView);
        }
    }
}
