namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface ITypeProductRepository : IBaseRepository<TypeProduct>
    {
        public TypeProduct GetByName(string name);
    }
}
