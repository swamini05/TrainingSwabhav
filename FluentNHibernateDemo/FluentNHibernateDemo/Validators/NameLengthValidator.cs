using System.ComponentModel.DataAnnotations;

namespace FluentNHibernateDemo.Validators
{
    public class NameLengthValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string name = value.ToString();
                if (name.Length > 3)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Name must be longer than 3 characters.");

        }
    }
}