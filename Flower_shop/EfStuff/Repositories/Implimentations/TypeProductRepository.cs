namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class TypeProductRepository : BaseRepository<TypeProduct>, ITypeProductRepository
    {
        public TypeProductRepository(WebDbContext context) : base(context)
        {
        }
        public async Task<TypeProduct> GetByNameAsync(string name)
        {
            return await _webContext.TypesProduct.SingleOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task RemoveTypeProductAsync(int id)
        {
            await _webContext.TypesProduct
                .OrderBy(x => x.Name)
                .Include(x => x.Products)
                .SingleOrDefaultAsync(x => x.Id == id);

            await _webContext.SaveChangesAsync();
        }

    }
}
