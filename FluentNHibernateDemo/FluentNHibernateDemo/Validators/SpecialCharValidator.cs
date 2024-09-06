using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FluentNHibernateDemo.Validators
{
    public class SpecialCharValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string name = value.ToString();
                if (name.All(c => char.IsLetter(c) || c == ' '))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Name should not contain special characters.");

        }
    }
}