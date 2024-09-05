using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OneToOneStudents
{
    public class NameValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string name = value.ToString();
                if (name.All(c => char.IsLetter(c)))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Name should only contains alphabets.");

        }
    }
}