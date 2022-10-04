using Flower_shop.EfStuff;
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
            var productsView = new List<ProductViewModel>
            {
                new ProductViewModel()
                {
                    Id = 0,
                    Name = "Коробочка цветов",
                    Price = "от 35 р.",
                    Img = "/img/flower10.jpg"
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
                new ProductViewModel()
                {
                    Id = 4,
                    Name = "Коробочка цветов",
                    Price = "от 35 р.",
                    Img = "/img/flower11.jpg",
                },
                new ProductViewModel
                {
                    Id = 5,
                    Name = "Конверт",
                    Price = "от хх р.",
                    Img = "/img/flower12.jpg"
                },
                new ProductViewModel()
                {
                    Id = 6,
                    Name = "Цветочная коробочка",
                    Price = "от хх р.",
                    Img = "/img/flower13.jpg"
                },
                new ProductViewModel
                {
                    Id = 7,
                    Name = "Конверт",
                    Price = "от хх р.",
                    Img = "/img/flower16.jpg"
                },
                new ProductViewModel()
                {
                    Id = 8,
                    Name = "Цветочная коробочка",
                    Price = "от хх р.",
                    Img = "/img/flower17.jpg"
                },
                new ProductViewModel()
                {
                    Id = 9,
                    Name = "Яркая композиция",
                    Price = "от хх р.",
                    Img = "/img/flower18.jpg"
                },
                new ProductViewModel()
                {
                    Id = 10,
                    Name = "Коробочка цветов",
                    Price = "от 35 р.",
                    Img = "/img/flower19.jpg",
                },
                new ProductViewModel
                {
                    Id = 11,
                    Name = "Конверт",
                    Price = "от хх р.",
                    Img = "/img/flower20.jpg"
                },
                new ProductViewModel()
                {
                    Id = 12,
                    Name = "Цветочная коробочка",
                    Price = "от хх р.",
                    Img = "/img/flower21.jpg"
                },
                new ProductViewModel()
                {
                    Id = 13,
                    Name = "Яркая композиция",
                    Price = "от хх р.",
                    Img = "/img/flower22.jpg"
                },
                new ProductViewModel()
                {
                    Id = 14,
                    Name = "Цветочная коробочка",
                    Price = "от хх р.",
                    Img = "/img/flower23.jpg"
                },
                new ProductViewModel()
                {
                    Id = 15,
                    Name = "Яркая композиция",
                    Price = "от хх р.",
                    Img = "/img/flower24.jpg"
                },
                new ProductViewModel()
                {
                    Id = 16,
                    Name = "Коробочка цветов",
                    Price = "от 35 р.",
                    Img = "/img/flower25.jpg",
                },
                new ProductViewModel
                {
                    Id = 17,
                    Name = "Конверт",
                    Price = "от хх р.",
                    Img = "/img/flower26.jpg"
                },
                new ProductViewModel()
                {
                    Id = 18,
                    Name = "Цветочная коробочка",
                    Price = "от хх р.",
                    Img = "/img/flower27.jpg"
                },
                new ProductViewModel()
                {
                    Id = 19,
                    Name = "Яркая композиция",
                    Price = "от хх р.",
                    Img = "/img/flower28.jpg"
                },
                new ProductViewModel()
                {
                    Id = 20,
                    Name = "Коробочка цветов",
                    Price = "от 35 р.",
                    Img = "/img/flower29.jpg",
                },
                new ProductViewModel
                {
                    Id = 21,
                    Name = "Конверт",
                    Price = "от хх р.",
                    Img = "/img/flower30.jpg"
                },
                new ProductViewModel()
                {
                    Id = 22,
                    Name = "Цветочная коробочка",
                    Price = "от хх р.",
                    Img = "/img/flower31.jpg"
                },
                new ProductViewModel()
                {
                    Id = 23,
                    Name = "Яркая композиция",
                    Price = "от хх р.",
                    Img = "/img/flower32.jpg"
                },
            };

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
        public IActionResult ProductEdition(ProductViewModel productView)
        {
            
            return View();
        }
    }
}
