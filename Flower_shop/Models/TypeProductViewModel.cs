using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Models
{
    public class TypeProductViewModel 
    {
        public int Id { get; set; } 
        public string Name { get; set; } = "";
        public List<string> ProductNames { get; set; }
    }
}
