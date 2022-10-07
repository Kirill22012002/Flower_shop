using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Flower_shop.Models.UserViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
