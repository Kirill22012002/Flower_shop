using Yandex.Checkout.V3;

namespace Flower_shop.Controllers
{
    public class IndexController : Controller
    {
        private IMapper _mapper;
        private IProductRepository _productRepository;
        private IImageRepository _imageRepository;
        private WebDbContext _dbContext;
        public IndexController(
            IMapper mapper,
            IProductRepository productRepository,
            IImageRepository imageRepository,
            WebDbContext dbContext)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _imageRepository = imageRepository;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var indexPageView = new IndexPageViewModel();
            indexPageView.Products = _mapper.Map<List<ProductViewModel>>(_productRepository.Take(4));
            indexPageView.Images = _mapper.Map<List<ImageViewModel>>(_imageRepository.GetAll());

            return View(indexPageView);
        }

        public IActionResult Pay()
        {
            return View();
        }

        [HttpGet]
        public string Paid()
        {
            return "Оплачено";
        }

    }
}
