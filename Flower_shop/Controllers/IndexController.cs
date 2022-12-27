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
        public async Task<IActionResult> Index()
        {
            var indexPageView = new IndexPageViewModel();
            indexPageView.Products = _mapper.Map<List<ProductViewModel>>(await _productRepository.TakeAsync(4));
            indexPageView.Images = _mapper.Map<List<ImageViewModel>>(await _imageRepository.GetAllAsync());

            return View(indexPageView);
        }
    }
}
