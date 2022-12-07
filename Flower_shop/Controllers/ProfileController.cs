namespace Flower_shop.Controllers
{
    public class ProfileController : Controller
    {
        private IMapper _mapper;
        private IUserService _userService;

        public ProfileController(
            IMapper mapper,
            IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public IActionResult MyProfile()
        { 
            return View(_mapper.Map<UserViewModel>(_userService.GetCurrent()));
        }
    }
}
