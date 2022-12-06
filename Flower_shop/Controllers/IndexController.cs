namespace Flower_shop.Controllers
{
    public class IndexController : Controller
    {
        private WebDbContext _dbContext;
        private IMapper _mapper;
        private ProductRepository _productRepository;
        private ImageRepository _imageRepository;
        public IndexController(
            WebDbContext dbContext,
            IMapper mapper,
            ProductRepository productRepository,
            ImageRepository imageRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _productRepository = productRepository;
            _imageRepository = imageRepository;
        }
        public IActionResult Index()
        {
            var indexPageView = new IndexPageViewModel();
            indexPageView.Products = _mapper.Map<List<ProductViewModel>>(_productRepository.Take(4));
            indexPageView.Images = _mapper.Map<List<ImageViewModel>>(_imageRepository.GetAll());

            return View(indexPageView);
        }
    }
}
