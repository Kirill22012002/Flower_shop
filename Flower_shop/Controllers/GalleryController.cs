using System.Collections.Generic;

namespace Flower_shop.Controllers
{
    public class GalleryController : Controller
    {
        private IMapper _mapper;
        private ITypeProductRepository _typeProductRepository;
        private IProductRepository _productRepository;

        public GalleryController(
            IMapper mapper,
            ITypeProductRepository typeProductRepository,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _typeProductRepository = typeProductRepository;
            _productRepository = productRepository; 
        }
        public async Task<IActionResult> Products(int typeId)
        {
            var typeDb = await _typeProductRepository.GetByIdAsync(typeId);
            if (typeDb is null)
            {
                return RedirectToRoute("default", new { controller = "Index", action = "Index" });
            }
            else
            {
                var product = _mapper.Map<List<ProductViewModel>>(await _productRepository.GetProductsByTypeIdAsync(typeId));
                return View(product);
            }
        }
        public IActionResult SingleProduct(ProductViewModel product)
        {
            return View(_mapper.Map<ProductViewModel>(product));
        }
    }
}
