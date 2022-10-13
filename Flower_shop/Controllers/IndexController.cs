using AutoMapper;
using Flower_shop.EfStuff;
using Flower_shop.EfStuff.Repositories;
using Flower_shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Controllers
{
    public class IndexController : Controller
    {
        private WebDbContext _dbContext;
        private IMapper _mapper;
        private ProductRepository _productRepository;
        public IndexController(
            WebDbContext dbContext,
            IMapper mapper,
            ProductRepository productRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var productsView = _mapper.Map<List<ProductViewModel>>(_productRepository.Take(4));

            return View(productsView);
        }
    }
}
