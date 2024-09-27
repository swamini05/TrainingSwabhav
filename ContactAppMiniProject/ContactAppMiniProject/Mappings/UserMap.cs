using ContactAppMiniProject.Models;
using FluentNHibernate.Mapping;

namespace ContactAppMiniProject.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(u => u.Id).GeneratedBy.GuidComb();
            Map(u => u.UserName);
            Map(u => u.Password);
            Map(u => u.Email);
            Map(u => u.FirstName);
            Map(u => u.LastName);
            Map(u => u.IsAdmin);
            Map(u => u.IsActive);
            HasMany(c => c.Contacts).Inverse().Cascade.All();
            HasOne(u => u.Role).PropertyRef(u => u.User).Cascade.All().Constrained();
        }
    }
}