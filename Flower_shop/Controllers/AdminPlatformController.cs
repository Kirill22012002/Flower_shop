using AutoMapper;
using Flower_shop.EfStuff;
using Flower_shop.EfStuff.DbModels;
using Flower_shop.EfStuff.DbModels.Enums;
using Flower_shop.Models;
using Flower_shop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Controllers
{
    
    public class AdminPlatformController : Controller
    {
        private IMapper _mapper;
        private WebDbContext _dbContext;
        private UserService _userService;
        public AdminPlatformController(
            IMapper mapper,
            WebDbContext dbContext, 
            UserService userService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _userService = userService;
        }

        public IActionResult Platform()
        {
            if (!_userService.IsAdmin())
            {
                return RedirectToRoute("default", new { controller = "Index", action = "Index" });
            }

            return View();
        }

        [HttpGet]
        public IActionResult ProductEdition()
        {
            if (!_userService.IsAdmin())
            {
                return RedirectToRoute("default", new { controller = "Index", action = "Index" });
            }
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

        [HttpGet]
        public IActionResult DeleteProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteProduct(int Id)
        {
            var productDb = _dbContext.Products.Single(x => x.Id == Id);
            _dbContext.Products.Remove(productDb);
            _dbContext.SaveChanges();

            return RedirectToRoute("default", new { controller = "Gallery", action = "Products" });
        }

    }
}
