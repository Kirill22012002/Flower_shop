using AutoMapper;
using Flower_shop.EfStuff;
using Flower_shop.Models;
using Flower_shop.Models.UserViewModels;
using Flower_shop.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Controllers
{
    public class ProfileController : Controller
    {
        private WebDbContext _dbContext;
        private IMapper _mapper;
        private UserService _userService;

        public ProfileController(
            WebDbContext dbContext,
            IMapper mapper,
            UserService userService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userService = userService;
        }

        public IActionResult MyProfile()
        {
            var userView = _mapper.Map<UserViewModel>(_userService.GetCurrent());
             
            return View(userView);
        }
    }
}
