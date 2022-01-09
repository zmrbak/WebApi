using System.ComponentModel.DataAnnotations;

namespace WebApi015.Validations
{
    public class NonSpaceAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value?.ToString()?.Contains(" ")==true)
            {
                return new ValidationResult("该字符串不允许包含空格");
            }

            return ValidationResult.Success;
        }
    }
}
