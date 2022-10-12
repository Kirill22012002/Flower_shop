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

            var typesView = _mapper.Map<List<TypeProductViewModel>>(_dbContext.TypesProduct.ToList());

            typesView.ForEach(x => x.Name = )

            var productView = new ProductViewModel() { TypesName = }


            TypesName
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductEdition(ProductViewModel productView)
        {

            if (productView.UploadedFile != null)
            {
                string path = "/files/" + productView.UploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await productView.UploadedFile.CopyToAsync(fileStream);

                }
                var productViewModel = new ProductViewModel { 
                    ImageName = productView.UploadedFile.Name, 
                    ImagePath = path, 
                    Name = productView.Name, 
                    Price = productView.Price
                };

                var productDb = _mapper.Map<Product>(productViewModel);

                _dbContext.Products.Add(productDb);
                _dbContext.SaveChanges();
            }

            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
        }
        [HttpGet]
        public IActionResult TypeEdition()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TypeEdition(TypeProductViewModel typeProductView)
        {
            var typeProductDb = _mapper.Map<TypeProduct>(typeProductView);
            _dbContext.TypesProduct.Add(typeProductDb);
            _dbContext.SaveChanges();

            return View();
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
