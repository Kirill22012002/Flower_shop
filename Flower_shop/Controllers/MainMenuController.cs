using Flower_shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Controllers
{
    public class MainMenuController : Controller
    {
        public IActionResult Index()
        {
            var productsView = new List<ProductViewModel>
            {
                new ProductViewModel()
                {
                    Id = 0,
                    Name = "Flower 0",
                    Price = "60$ - 70$",
                    ImageUrl = "/images/flower1.jpg",
                },
                new ProductViewModel
                {
                    Id = 1,
                    Name = "Flower 1",
                    Price = "80$ - 90$",
                    ImageUrl = "/images/flower2.jpg"
                },
                new ProductViewModel()
                {
                    Id = 2,
                    Name = "Flower 0",
                    Price = "110$ - 120$",
                    ImageUrl = "/images/flower3.jpg"
                },
                new ProductViewModel()
                {
                    Id = 3,
                    Name = "Flower 3",
                    Price = "50$ - 70$",
                    ImageUrl = "/images/flower4.jpg"
                },
            };
            
            return View(productsView);
        }
    }
}
