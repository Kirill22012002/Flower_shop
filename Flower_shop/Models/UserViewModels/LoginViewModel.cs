namespace Flower_shop.Models.UserViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите Email")]
        [EmailVerification]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [PasswordVerification]
        public string Password { get; set; }

    }
}
