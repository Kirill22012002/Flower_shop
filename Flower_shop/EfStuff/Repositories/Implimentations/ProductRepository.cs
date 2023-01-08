namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(WebDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetAllAsync(bool onlyInTrash = true)
        {
            return await _dbSet
                .Where(x => x.IsInTrash == onlyInTrash)
                .ToListAsync();
        }

        public async Task<bool> MoveProductToTrash(int productId)
        {
            try
            {
                var product = GetById(productId);
                if (product.IsInTrash) 
                {
                    return false;
                }

                product.IsInTrash = true;
                await _webContext.SaveChangesAsync();
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }

        public async Task<List<Product>> TakeAsync(int count, bool onlyInTrash = false)
        {
            return await _webContext.Products
                .Where(x => x.IsInTrash == onlyInTrash)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByTypeIdAsync(int typeId) 
        {
            return await _dbSet
                .Where(x => x.TypeProduct.Id == typeId && x.IsInTrash == false)
                .ToListAsync();
        }
    }
}