using System.ComponentModel.DataAnnotations;

namespace OneToOneStudents.Models
{
    public class Student
    {
        public virtual int Id { get; set; }

        [Required]
        [NameValidator]
        public virtual string Name { get; set; }

        [Required]
        [Range(16, 25)]
        public virtual int Age { get; set; }

        [Required]
        [EmailAddress]
        public virtual string Email { get; set; }

        public virtual Course Course { get; set; }
    }
}