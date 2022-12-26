namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmAndPassAsync(string email, string pass);
        bool IsEmailExist(string email);
        Task<bool> IsEmailExistAsync(string email);
        bool IsPasswordExist(string password);
        Task<bool> IsPasswordExistAsync(string password);
    }
}
