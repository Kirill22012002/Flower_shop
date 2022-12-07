namespace Flower_shop.Controllers
{
    public class IndexController : Controller
    {
        private IMapper _mapper;
        private IProductRepository _productRepository;
        private IImageRepository _imageRepository;
        public IndexController(
            IMapper mapper,
            IProductRepository productRepository,
            IImageRepository imageRepository)
        {
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
