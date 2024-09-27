using ContactAppMiniProject.Models;
using FluentNHibernate.Mapping;

namespace ContactAppMiniProject.Mappings
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Table("Role");
            Id(r => r.Id).GeneratedBy.Identity();
            Map(r => r.RoleName);
            References(r => r.User).Column("UserId").Cascade.None().Unique();
        }
    }
}