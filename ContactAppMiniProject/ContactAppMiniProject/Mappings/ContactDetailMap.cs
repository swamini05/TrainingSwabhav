using ContactAppMiniProject.Models;
using FluentNHibernate.Mapping;

namespace ContactAppMiniProject.Mappings
{
    public class ContactDetailMap : ClassMap<ContactDetail>
    {
        public ContactDetailMap()
        {
            {
                Table("ContactDetails");
                Id(d => d.Id).GeneratedBy.Identity();
                Map(d => d.Type);
                Map(d => d.Value);
                References(d => d.Contact).Column("ContactId").Cascade.None().Nullable();
            }
        }
    }
}