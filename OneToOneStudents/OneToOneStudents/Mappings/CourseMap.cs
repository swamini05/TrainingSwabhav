using FluentNHibernate.Mapping;
using OneToOneStudents.Models;

namespace OneToOneStudents.Mappings
{
    public class CourseMap : ClassMap<Course>
    {
        public CourseMap()
        {
            Table("Courses");
            Id(c => c.Id).GeneratedBy.Identity();
            Map(c => c.Name);
            Map(c => c.Duration);
            References(a => a.Student).Column("Student_id").Unique().Cascade.None();
        }
    }
}