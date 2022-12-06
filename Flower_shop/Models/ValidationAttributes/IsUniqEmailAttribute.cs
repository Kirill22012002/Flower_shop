namespace Flower_shop.Models.ValidationAttributes
{
    public class IsUniqEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, 
            ValidationContext validationContext)
        {
            var userRepository = validationContext.GetService(typeof(UserRepository)) as UserRepository;

            var email = value?.ToString();
            var isDublicate = userRepository.IsEmailExist(email);
            if (isDublicate)
            {
                return new ValidationResult("Такой email уже существует");
            }
            return ValidationResult.Success;
        }
    }
}