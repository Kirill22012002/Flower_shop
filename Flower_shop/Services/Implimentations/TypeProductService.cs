namespace Flower_shop.Services.Implimentations
{
    public class TypeProductService : ITypeProductService
    {
        private WebDbContext _dbContext;

        public TypeProductService(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<TypeProductViewModel> GetTypesName()
        {
            var typeProductView = _dbContext.TypesProduct.Select(x => new TypeProductViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return typeProductView;
        }
    }
}
