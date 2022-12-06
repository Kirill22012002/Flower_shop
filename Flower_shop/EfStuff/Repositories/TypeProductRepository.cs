namespace Flower_shop.EfStuff.Repositories
{
    public class TypeProductRepository : BaseRepository<TypeProduct>
    {
        public TypeProductRepository(WebDbContext context) : base(context)
        {
        }
        public TypeProduct GetByName(string name)
        {
            return _webContext.TypesProduct.SingleOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
        
    }
}
