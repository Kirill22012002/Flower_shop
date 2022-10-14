using AutoMapper;
using Flower_shop.EfStuff;
using Flower_shop.EfStuff.DbModels;
using Flower_shop.EfStuff.DbModels.Enums;
using Flower_shop.EfStuff.Repositories;
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
        private ProductRepository _productRepository;
        private TypeProductRepository _typeProductRepository;
        public AdminPlatformController(
            IMapper mapper,
            WebDbContext dbContext,
            UserService userService,
            IWebHostEnvironment appEnvironment,
            ProductRepository productRepository,
            TypeProductRepository typeProductRepository)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _userService = userService;
            _appEnvironment = appEnvironment;
            _productRepository = productRepository;
            _typeProductRepository = typeProductRepository;
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

            var typeView = _mapper.Map<List<TypeProductViewModel>>(_dbContext.TypesProduct.ToList());

            var typeName = new List<string>();

            foreach(var name in typeView)
            {
                typeName.Add(name.Name);
            }

            var productView = new ProductViewModel()
            {
                TypesName = typeName
            };


            return View(productView);
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

                var typeProduct = _typeProductRepository.GetByName(productView.TypeName);

                var productDb = _mapper.Map<Product>(productViewModel);
                productDb.TypeProduct = typeProduct;

                _productRepository.Save(productDb);
            }

            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
        }
        [HttpGet]
        public IActionResult TypeProductEdition()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TypeProductEdition(TypeProductViewModel typeProductView)
        {
            var typeProductDb = _mapper.Map<TypeProduct>(typeProductView);
            _typeProductRepository.Save(typeProductDb);

            return View();
        }
        [HttpGet]
        public IActionResult ProductDelete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProductDelete(int id)
        {
            _productRepository.Remove(_productRepository.Get(id));

            return RedirectToRoute("default", new { controller = "Gallery", action = "Products" });
        }
    }
}
