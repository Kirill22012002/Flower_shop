namespace Flower_shop.Models.ValidationAttributes
{
    public class PasswordVerificationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, 
            ValidationContext validationContext)
        {
            var password = value?.ToString();
            var repository = validationContext.GetService(typeof(UserRepository)) as UserRepository;
            var user = repository.IsPasswordExist(password);
            if (!user)
            {
                return new ValidationResult("Неверный пароль!");
            }
            return ValidationResult.Success;
        }
    }
}
