﻿using Flower_shop.Models.UserViewModels;
using GoogleAuthentication.Services;
using Newtonsoft.Json;
using System.Text.Json;

namespace Flower_shop.Controllers
{
    public class AuthenticationController : Controller
    {
        private IMapper _mapper;
        private IConfiguration _config;
        private IUserRepository _userRepository;
        public AuthenticationController(
            IMapper mapper,
            IConfiguration config,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _config = config;
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegisterViewModel registerView)
        {
            if (ModelState.IsValid)
            {
                var userDb = _mapper.Map<User>(registerView);
                userDb.Role = SiteRole.User;

                _userRepository.Save(userDb);

                var claims = new List<Claim>()
                {
                    new Claim("Id", userDb.Id.ToString()),
                    new Claim("Name", userDb.FirstName),
                    new Claim(ClaimTypes.AuthenticationMethod, _config.GetSection("ConnectionStrings").GetSection("AuthName").Value)
                };

                var identity = new ClaimsIdentity(claims, _config.GetSection("ConnectionStrings").GetSection("AuthName").Value);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);

                return RedirectToRoute("default", new { controller = "Index", action = "Index" });
            }

            return View();
        }
        [HttpGet]
        public IActionResult Autorization()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Autorization(LoginViewModel userView)
        {
            var user = _userRepository.GetByEmAndPass(userView.Email, userView.Password);

            if (user == null)
            {
                return View();
            }

            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Name", user.FirstName),
                new Claim(ClaimTypes.AuthenticationMethod, _config.GetSection("ConnectionStrings").GetSection("AuthName").Value)
            };

            var identity = new ClaimsIdentity(claims, _config.GetSection("ConnectionStrings").GetSection("AuthName").Value);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);

            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
        }
        public async Task<IActionResult> RedirectGoogleLogin(string code)
        {
            var clientId = "291864101397-ifa7rc84i92op5t71pj674caqi9eeb96.apps.googleusercontent.com";
            var redirectUrl = "https://localhost:7291/Authentication/RedirectGoogleLogin";
            var clientSecret = "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";

            var token = await GoogleAuth.GetAuthAccessToken(code, clientId,clientSecret, redirectUrl);
            var userProfile = await GoogleAuth.GetProfileResponseAsync(token.AccessToken.ToString());

            var googleUser = JsonConvert.DeserializeObject<GoogleUserViewModel>(userProfile);
            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
        }
    }
}
