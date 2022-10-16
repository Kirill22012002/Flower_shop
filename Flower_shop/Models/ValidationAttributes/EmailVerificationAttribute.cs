using Flower_shop.EfStuff.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Flower_shop.Models.ValidationAttributes
{
    public class EmailVerificationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, 
            ValidationContext validationContext)
        {
            var email = value?.ToString();
            var repository = validationContext.GetService(typeof(UserRepository)) as UserRepository;
            var user = repository.IsEmailExist(email);
            if (!user)
            {
                return new ValidationResult("Неверный email!");
            }
            return ValidationResult.Success;
        }
    }
}
