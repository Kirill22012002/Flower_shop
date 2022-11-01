using Flower_shop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flower_shop.EfStuff.DbModels
{
    public class ImageViewModel
    {
        public int Block { get; set; }
        public string Title { get; set; } = "";
        public string Subtitle { get; set; } = "";
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public IFormFile UploadedFile { get; set; }

    }
}
