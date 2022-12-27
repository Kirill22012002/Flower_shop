namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IColorRepository : IBaseRepository<Color>
    {
        Color GetByAssignment(string name);
    }
}
