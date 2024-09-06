using System.ComponentModel.DataAnnotations;

namespace FluentNHibernateDemo.Validators
{
    public class UppercaseValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string name = value.ToString();
                if (char.IsUpper(name[0]))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("First letter should be Uppercase.");

        }
    }
}