using AutoMapper;
using Flower_shop.EfStuff;
using Flower_shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Controllers
{
    public class IndexController : Controller
    {
        private WebDbContext _dbContext;
        private IMapper _mapper;
        public IndexController(
            WebDbContext dbContext, 
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
/*            var productsView = _mapper.Map<List<ProductViewModel>>(_dbContext.Products.Take(4));
*/
/*            return View(productsView);
*/            return View();
        }
    }
}
