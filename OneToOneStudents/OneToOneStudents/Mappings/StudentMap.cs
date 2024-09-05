using FluentNHibernate.Mapping;
using OneToOneStudents.Models;

namespace OneToOneStudents.Mappings
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Table("Students");
            Id(s => s.Id).GeneratedBy.Identity();
            Map(s => s.Name);
            Map(s => s.Age);
            Map(s => s.Email);
            HasOne(s => s.Course).Cascade.All().PropertyRef(a => a.Student).Constrained();
        }
    }
}