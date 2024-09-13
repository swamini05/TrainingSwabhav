using FluentNHibernate.Mapping;
using HashingDemo.Models;

namespace HashingDemo.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(u => u.Id).GeneratedBy.Identity();
            Map(u => u.Username);
            Map(u => u.Password);
        }
    }
}