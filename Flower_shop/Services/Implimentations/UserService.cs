namespace Flower_shop.Services.Implimentations
{
    public class UserService : IUserService
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IUserRepository _userRepository;

        public UserService(
            IHttpContextAccessor httpContextAccessor,
             IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public User GetCurrent()
        {
            var idStr = _httpContextAccessor
                .HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type == "Id")
                ?.Value;

            if (idStr == null)
            {
                return null;
            }
            var id = Convert.ToInt64(idStr);

            var user = _userRepository.GetById(id);
            return user;
        }
        public bool HasRole(SiteRole role)
        {
            return GetCurrent()?.Role.HasFlag(role) ?? false;
        }
        public bool IsAdmin()
        {
            return HasRole(SiteRole.Admin);
        }
    }
}
