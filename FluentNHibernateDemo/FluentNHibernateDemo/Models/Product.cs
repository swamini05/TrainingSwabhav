using System.ComponentModel.DataAnnotations;
using FluentNHibernateDemo.Validators;

namespace FluentNHibernateDemo.Models
{
    public class Product
    {
        public virtual int Id { get; set; }

        [Required]
        [NameLengthValidator]
        [UppercaseValidator]
        [SpecialCharValidator]
        public virtual string Name { get; set; }

        [Required]
        public virtual string Description { get; set; }


    }
}