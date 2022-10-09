
using Flower_shop.Models;

namespace Flower_shop.EfStuff.DbModels
{
    public class Product
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Price { get; set; } = "";
        public ProductImage ProductImage { get; set; }  
        public string Type { get; set; } = "";

    }
}
