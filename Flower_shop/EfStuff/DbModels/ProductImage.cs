using Flower_shop.EfStuff.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
