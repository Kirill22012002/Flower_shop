namespace Flower_shop.Services.Interfaces
{
    public interface IUserService
    {
        public User GetCurrent();
        public bool HasRole(SiteRole role);
        public bool IsAdmin();
    }
}
