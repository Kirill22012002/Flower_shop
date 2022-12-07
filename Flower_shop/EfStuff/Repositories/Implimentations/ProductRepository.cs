namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(WebDbContext context) : base(context)
        {
        }
        public List<Product> Take(int count) => _webContext.Products.Take(count).ToList();

    }
}