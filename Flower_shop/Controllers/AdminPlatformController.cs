using Flower_shop.Services.Implimentations;

namespace Flower_shop.Controllers
{
    public class AdminPlatformController : Controller
    {
        private IMapper _mapper;
        private UserService _userService;
        private WebDbContext _dbContext;
        private IWebHostEnvironment _appEnvironment;
        private IProductRepository _productRepository;
        private ITypeProductRepository _typeProductRepository;
        private IImageRepository _imageRepository;
        public AdminPlatformController(
            IMapper mapper,
            UserService userService,
            WebDbContext dbContext,
            IWebHostEnvironment appEnvironment,
            IProductRepository productRepository,
            ITypeProductRepository typeProductRepository,
            IImageRepository imageRepository)
        {
            _mapper = mapper;
            _userService = userService;
            _dbContext = dbContext;
            _appEnvironment = appEnvironment;
            _productRepository = productRepository;
            _typeProductRepository = typeProductRepository;
            _imageRepository = imageRepository;
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

            var typeView = _mapper.Map<List<TypeProductViewModel>>(_typeProductRepository.GetAll());

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
            var typesDb = _typeProductRepository.GetAll();

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
        public IActionResult TypeProductEdition(TypeProductViewModel typeProductView)
        {
            var typeProductDb = _mapper.Map<TypeProduct>(typeProductView);
            _typeProductRepository.Save(typeProductDb);

            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
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

            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
        }
        [HttpGet]
        public IActionResult TypeProductDelete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TypeProductDelete(int typeId)
        {
            var typeWithProducts = _dbContext.TypesProduct
                .OrderBy(x => x.Name)
                .Include(x => x.Products)
                .FirstOrDefault(x => x.Id == typeId);

            _dbContext.Remove(typeWithProducts);
            _dbContext.SaveChanges();

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

                var imageDb = _imageRepository.GetByBlock(imageViewModel.Block);

                imageDb.ImageName = imageViewModel.UploadedFile.Name;
                imageDb.ImagePath = path;
                imageDb.Title = imageViewModel.Title;
                imageDb.Subtitle = imageViewModel.Subtitle;

                _dbContext.SaveChanges();
            }

            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
        }
    }
}
