using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Flower_shop.Models.UserViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введён неверно")]
        public string ConfirmPassword { get; set; }

    }
}
