namespace Flower_shop.Models
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public string Price { get; set; } = "";
        public IFormFile UploadedFile { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public List<string> TypesName { get; set; }
        public string TypeName { get; set; } = "Цветы";

    }
}