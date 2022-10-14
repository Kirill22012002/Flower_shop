using AutoMapper;
using Flower_shop.EfStuff;
using Flower_shop.EfStuff.DbModels;
using Flower_shop.EfStuff.Repositories;
using Flower_shop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Controllers
{
    public class GalleryController : Controller
    {
        private WebDbContext _dbContext;
        private IMapper _mapper;
        private ProductRepository _productRepository;

        public GalleryController(
            WebDbContext dbContext,
            IMapper mapper,
            ProductRepository productRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public IActionResult Products()
        {
            var productsView = _mapper.Map<List<ProductViewModel>>(_productRepository.GetAll());

            return View(productsView);
        }
        public IActionResult SingleProduct(ProductViewModel product)
        {
            var productView = _mapper.Map<ProductViewModel>(product);

            return View(productView);
        }
    }
}
