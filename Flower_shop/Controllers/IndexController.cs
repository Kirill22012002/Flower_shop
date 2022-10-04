using Flower_shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            var productsView = new List<ProductViewModel>
            {
                new ProductViewModel()
                {
                    Id = 0,
                    Name = "Коробочка цветов",
                    Price = "от 35 р.",
                    Img = "/img/flower10.jpg",
                },
                new ProductViewModel
                {
                    Id = 1,
                    Name = "Конверт",
                    Price = "от хх р.",
                    Img = "/img/flower11.jpg"
                },
                new ProductViewModel()
                {
                    Id = 2,
                    Name = "Цветочная коробочка",
                    Price = "от хх р.",
                    Img = "/img/flower12.jpg"
                },
                new ProductViewModel()
                {
                    Id = 3,
                    Name = "Яркая композиция",
                    Price = "от хх р.",
                    Img = "/img/flower13.jpg"
                },
            };
            
            return View(productsView);
        }
    }
}
