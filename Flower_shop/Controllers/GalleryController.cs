﻿using Flower_shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Products()
        {
            var productsView = new List<ProductViewModel>
            {
                new ProductViewModel()
                {
                    Id = 0,
                    Name = "Коробочка цветов",
                    Price = "от 35 р.",
                    ImageUrl = "/img/flower10.jpg"
                },
                new ProductViewModel
                {
                    Id = 1,
                    Name = "Конверт",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower11.jpg"
                },
                new ProductViewModel()
                {
                    Id = 2,
                    Name = "Цветочная коробочка",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower12.jpg"
                },
                new ProductViewModel()
                {
                    Id = 3,
                    Name = "Яркая композиция",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower13.jpg"
                },
                new ProductViewModel()
                {
                    Id = 4,
                    Name = "Коробочка цветов",
                    Price = "от 35 р.",
                    ImageUrl = "/img/flower11.jpg",
                },
                new ProductViewModel
                {
                    Id = 5,
                    Name = "Конверт",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower12.jpg"
                },
                new ProductViewModel()
                {
                    Id = 6,
                    Name = "Цветочная коробочка",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower13.jpg"
                },
                new ProductViewModel
                {
                    Id = 7,
                    Name = "Конверт",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower16.jpg"
                },
                new ProductViewModel()
                {
                    Id = 8,
                    Name = "Цветочная коробочка",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower17.jpg"
                },
                new ProductViewModel()
                {
                    Id = 9,
                    Name = "Яркая композиция",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower18.jpg"
                },
                new ProductViewModel()
                {
                    Id = 10,
                    Name = "Коробочка цветов",
                    Price = "от 35 р.",
                    ImageUrl = "/img/flower19.jpg",
                },
                new ProductViewModel
                {
                    Id = 11,
                    Name = "Конверт",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower20.jpg"
                },
                new ProductViewModel()
                {
                    Id = 12,
                    Name = "Цветочная коробочка",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower21.jpg"
                },
                new ProductViewModel()
                {
                    Id = 13,
                    Name = "Яркая композиция",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower22.jpg"
                },
                new ProductViewModel()
                {
                    Id = 14,
                    Name = "Цветочная коробочка",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower23.jpg"
                },
                new ProductViewModel()
                {
                    Id = 15,
                    Name = "Яркая композиция",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower24.jpg"
                },
                new ProductViewModel()
                {
                    Id = 16,
                    Name = "Коробочка цветов",
                    Price = "от 35 р.",
                    ImageUrl = "/img/flower25.jpg",
                },
                new ProductViewModel
                {
                    Id = 17,
                    Name = "Конверт",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower26.jpg"
                },
                new ProductViewModel()
                {
                    Id = 18,
                    Name = "Цветочная коробочка",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower27.jpg"
                },
                new ProductViewModel()
                {
                    Id = 19,
                    Name = "Яркая композиция",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower28.jpg"
                },
                new ProductViewModel()
                {
                    Id = 20,
                    Name = "Коробочка цветов",
                    Price = "от 35 р.",
                    ImageUrl = "/img/flower29.jpg",
                },
                new ProductViewModel
                {
                    Id = 21,
                    Name = "Конверт",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower30.jpg"
                },
                new ProductViewModel()
                {
                    Id = 22,
                    Name = "Цветочная коробочка",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower31.jpg"
                },
                new ProductViewModel()
                {
                    Id = 23,
                    Name = "Яркая композиция",
                    Price = "от хх р.",
                    ImageUrl = "/img/flower32.jpg"
                },
            };

            return View(productsView);
        }
        public IActionResult SingleProduct(string productUrl, string productName, string productPrice)
        {
            ProductViewModel productModel = new ProductViewModel
            {
                Name = productName,
                ImageUrl = productUrl,
                Price = productPrice
            };
            return View(productModel);
        }
    }
}