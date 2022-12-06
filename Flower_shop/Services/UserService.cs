namespace Flower_shop.Services
{
    public class UserService
    {
        private IHttpContextAccessor _httpContextAccessor;
        private WebDbContext _dbContext;

        public UserService(
            IHttpContextAccessor httpContextAccessor, 
            WebDbContext dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }

        public User GetCurrent()
        {
            var idStr = _httpContextAccessor
                .HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type == "Id")
                ?.Value;

            if(idStr == null)
            {
                return null;
            }
            var id = int.Parse(idStr);

            var user = _dbContext.Users.SingleOrDefault(x => x.Id == id);
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
