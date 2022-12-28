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
        public async Task<IActionResult> Products(long typeId)
        {
            var typeDb = await _typeProductRepository.GetByIdAsync(typeId);
            if (typeDb is null)
            {
                return RedirectToRoute("default", new { controller = "Index", action = "Index" });
            }
            else
            {
                return View(_mapper.Map<List<ProductViewModel>>(typeDb.Products));
            }
        }
        public IActionResult SingleProduct(ProductViewModel product)
        {
            return View(_mapper.Map<ProductViewModel>(product));
        }
    }
}
