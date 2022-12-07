using Flower_shop.EfStuff.Repositories.Implimentations;

namespace Flower_shop.Models.ValidationAttributes
{
    public class EmailVerificationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, 
            ValidationContext validationContext)
        {
            var email = value?.ToString();
            var repository = validationContext.GetService(typeof(IUserRepository)) as IUserRepository;
            var user = repository.IsEmailExist(email);
            if (!user)
            {
                return new ValidationResult("Неверный email!");
            }
            return ValidationResult.Success;
        }
    }
}
