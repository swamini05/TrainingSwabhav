using System.ComponentModel.DataAnnotations;
using OneToOneStudents.Validators;

namespace OneToOneStudents.Models
{
    public class Course
    {
        public virtual int Id { get; set; }

        [Required]
        [SpecialCharValidator]
        public virtual string Name { get; set; }

        [Required]
        [Range(1, 3)]
        public virtual int Duration { get; set; }

        public virtual Student Student { get; set; }
    }
}