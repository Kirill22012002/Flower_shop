namespace Flower_shop.Models
{
    public class TypeProductViewModel 
    {
        public long Id { get; set; } 
        public string Name { get; set; } = "";
        public List<string> ProductNames { get; set; }
        public List<TypeProductViewModel> TypeProducts { get; set; }
    }
}
