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
        private IWebHostEnvironment _appEnvironment;
        public AdminPlatformController(
            IMapper mapper,
            WebDbContext dbContext,
            UserService userService,
            IWebHostEnvironment appEnvironment)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _userService = userService;
            _appEnvironment = appEnvironment;
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
        public async Task<IActionResult> ProductEdition(ProductViewModel productView)
        {
            var productDb = _mapper.Map<Product>(productView);

            if (productView.UploadedFile != null)
            {
                string path = "/files/" + productView.UploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await productView.UploadedFile.CopyToAsync(fileStream);

                }
                var file = new ProductImage { Name = productView.UploadedFile.Name, Path = path, Product = productDb };

                _dbContext.ProductImage.Add(file);
                _dbContext.SaveChanges();
                productDb.ProductImage = file;
            }


            _dbContext.Products.Add(productDb);
            _dbContext.SaveChanges();

            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
        }

        [HttpGet]
        public IActionResult ProductDelete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProductDelete(int Id)
        {
            var productDb = _dbContext.Products.Single(x => x.Id == Id);
            _dbContext.Products.Remove(productDb);
            _dbContext.SaveChanges();

            return RedirectToRoute("default", new { controller = "Gallery", action = "Products" });
        }

    }
}
