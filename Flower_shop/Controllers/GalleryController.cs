﻿using AutoMapper;
using Flower_shop.EfStuff;
using Flower_shop.EfStuff.DbModels;
using Flower_shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Controllers
{
    public class GalleryController : Controller
    {
        private WebDbContext _dbContext;
        private IMapper _mapper;

        public GalleryController(
            WebDbContext dbContext, 
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
        public IActionResult SingleProduct(ProductViewModel product)
        {
            var productView = _mapper.Map<ProductViewModel>(product);

            return View(productView);
        }
        [HttpGet]
        public IActionResult ProductEdition()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProductEdition(ProductViewModel productView)
        {
            var productDb = _mapper.Map<Product>(productView);

            _dbContext.Products.Add(productDb);
            _dbContext.SaveChanges();

            return View();
        }
    }
}
