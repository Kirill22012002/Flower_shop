using Flower_shop.Services.Implimentations;
using Microsoft.AspNetCore.Authorization;

namespace Flower_shop.Controllers
{
    public class AdminPlatformController : Controller
    {
        private IMapper _mapper;
        private IUserService _userService;
        private WebDbContext _dbContext;
        private IWebHostEnvironment _appEnvironment;
        private IProductRepository _productRepository;
        private ITypeProductRepository _typeProductRepository;
        private IImageRepository _imageRepository;
        private IUserRepository _userRepository;
        public AdminPlatformController(
            IMapper mapper,
            IUserService userService,
            WebDbContext dbContext,
            IWebHostEnvironment appEnvironment,
            IProductRepository productRepository,
            ITypeProductRepository typeProductRepository,
            IImageRepository imageRepository,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userService = userService;
            _dbContext = dbContext;
            _appEnvironment = appEnvironment;
            _productRepository = productRepository;
            _typeProductRepository = typeProductRepository;
            _imageRepository = imageRepository;
            _userRepository = userRepository;
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
        public async Task<IActionResult> ProductEdition()
        {
            if (!_userService.IsAdmin())
            {
                return RedirectToRoute("default", new { controller = "Index", action = "Index" });
            }

            var typeView = _mapper.Map<List<TypeProductViewModel>>(await _typeProductRepository.GetAllAsync());

            var typeName = new List<string>();

            foreach (var name in typeView)
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
                var productViewModel = new ProductViewModel
                {
                    ImageName = productView.UploadedFile.Name,
                    ImagePath = path,
                    Name = productView.Name,
                    Price = productView.Price
                };

                var typeProduct = await _typeProductRepository.GetByNameAsync(productView.TypeName);

                var productDb = _mapper.Map<Product>(productViewModel);
                productDb.TypeProduct = typeProduct;

                await _productRepository.SaveAsync(productDb);
            }

            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
        }
        [HttpGet]
        public async Task<IActionResult> TypeProductEdition()
        {
            var typesDb = await _typeProductRepository.GetAllAsync();

            var typeView = new TypeProductViewModel
            {
                TypeProducts = typesDb.Select(x => new TypeProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()

            };
            return View(typeView);
        }
        [HttpPost]
        public async Task<IActionResult> TypeProductEdition(TypeProductViewModel typeProductView)
        {
            var typeProductDb = _mapper.Map<TypeProduct>(typeProductView);
            await _typeProductRepository.SaveAsync(typeProductDb);

            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ProductDelete(int id)
        {
            if (!await _productRepository.MoveProductToTrash(id)) 
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult TypeProductDelete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TypeProductDelete(int typeId)
        {
            await _typeProductRepository.RemoveTypeProductAsync(typeId);

            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
        }
        [HttpGet]
        public IActionResult ImageEdition(int block)
        {
            var imageView = new ImageViewModel
            {
                Block = block
            };
            return View(imageView);
        }
        [HttpPost]
        public async Task<IActionResult> ImageEdition(ImageViewModel imageViewModel)
        {
            if (imageViewModel.UploadedFile != null)
            {
                string path = "/files/" + imageViewModel.UploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await imageViewModel.UploadedFile.CopyToAsync(fileStream);
                }

                var imageDb = await _imageRepository.GetByBlockAsync(imageViewModel.Block);

                imageDb.ImageName = imageViewModel.UploadedFile.Name;
                imageDb.ImagePath = path;
                imageDb.Title = imageViewModel.Title;
                imageDb.Subtitle = imageViewModel.Subtitle;

                await _dbContext.SaveChangesAsync();
            }

            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            if (_userService.IsAdmin())
            {
                return View(_mapper.Map<List<UserViewModel>>(await _userRepository.GetAllAsync()));
            }
            else
            {
                return Redirect("~/Index/Index");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetProductsInTrash()
        {
            //тут берем только продукты из корзины
            var products = _mapper
                .Map<List<ProductViewModel>>(await _productRepository.GetAllAsync(onlyInTrash: true));
            
            return View(products);

        }
    }
}
