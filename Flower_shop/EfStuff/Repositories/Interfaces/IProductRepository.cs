namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        public List<Product> Take(int count);
    }
}
