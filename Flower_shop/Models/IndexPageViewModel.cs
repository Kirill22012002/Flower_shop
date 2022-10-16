using Flower_shop.EfStuff.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Models
{
    public class IndexPageViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public List<ImageViewModel> Images { get; set; }
    }
}
