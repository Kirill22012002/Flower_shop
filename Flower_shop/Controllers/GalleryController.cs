namespace Flower_shop.Controllers
{
    public class GalleryController : Controller
    {
        private IMapper _mapper;
        private ITypeProductRepository _typeProductRepository;

        public GalleryController(
            IMapper mapper,
            ITypeProductRepository typeProductRepository)
        {
            _mapper = mapper;
            _typeProductRepository = typeProductRepository;
        }
        public IActionResult Products(int typeId)
        {
            var typeDb = _typeProductRepository.Get(typeId);
            if (typeDb is null)
                return RedirectToRoute("default", new { controller = "Index", action = "Index" });
            
            return View(_mapper.Map<List<ProductViewModel>>(typeDb.Products));
        }
        public IActionResult SingleProduct(ProductViewModel product)
        {
            return View(_mapper.Map<ProductViewModel>(product));
        }
    }
}
