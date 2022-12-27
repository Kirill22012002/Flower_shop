namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<Product>> TakeAsync(int count);
    }
}
