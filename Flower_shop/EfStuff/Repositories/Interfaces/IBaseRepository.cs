namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<T> GetByIdAsync(long id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T model);
        Task<bool> TryAddAsync(T model);
        Task AddAllAsync(List<T> models);
        Task UpdateAsync(T model);
        Task DeleteAsync(T model);
        Task DeleteByIdAsync(long id);

    }
}
