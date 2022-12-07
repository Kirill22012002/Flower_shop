namespace Flower_shop.Models.UserViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; }
        public SiteRole Role { get; set; }
    }
}
