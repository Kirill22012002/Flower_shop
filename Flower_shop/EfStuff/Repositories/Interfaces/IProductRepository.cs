namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<Product>> TakeAsync(int count, bool onlyInTrash = false);
        Task<List<Product>> GetAllAsync(bool onlyInTrash = true);
        Task<bool> MoveProductToTrash(int productId);
        Task<List<Product>> GetProductsByTypeIdAsync(int typeId);

    }
}
