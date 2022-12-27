namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<bool> AnyAsync();

        T GetById(long id);

        Task<T> GetByIdAsync(long id);

        Task<List<T>> GetAllAsync();

        Task SaveAsync(T model);

        Task SaveListAsync(IEnumerable<T> models);

        Task RemoveAsync(T model);

        Task RemoveByIdAsync(long id);

        Task<int> CountAsync();
    }
}
