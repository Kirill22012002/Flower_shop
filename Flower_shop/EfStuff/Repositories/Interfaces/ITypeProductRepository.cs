namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface ITypeProductRepository : IBaseRepository<TypeProduct>
    {
        Task<TypeProduct> GetByNameAsync(string name);
        Task RemoveTypeProductAsync(int id);
    }
}
