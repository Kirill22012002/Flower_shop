namespace Flower_shop.EfStuff.Repositories
{
    public class ProductRepository : BaseRepository<Product> 
    {
        public ProductRepository(WebDbContext context) : base(context)
        {
        }
        public List<Product> Take(int count) => _webContext.Products.Take(count).ToList();

    }
}