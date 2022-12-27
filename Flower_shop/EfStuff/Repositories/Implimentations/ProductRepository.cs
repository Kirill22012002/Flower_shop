namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(WebDbContext context) : base(context)
        {
        }
        public async Task<List<Product>> TakeAsync(int count)
        {
            return await _webContext.Products.Take(count).ToListAsync();
        }
    }
}