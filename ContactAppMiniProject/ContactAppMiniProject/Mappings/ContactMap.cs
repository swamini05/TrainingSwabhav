using ContactAppMiniProject.Models;
using FluentNHibernate.Mapping;

namespace ContactAppMiniProject.Mappings
{
    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Table("Contacts");
            Id(c => c.Id).GeneratedBy.Identity();
            Map(c => c.FirstName);
            Map(c => c.LastName);
            Map(c => c.IsActive);
            HasMany(c => c.ContactDetailsList).Inverse().Cascade.All();
            References(c => c.User).Column("UserId").Cascade.None().Nullable();
        }
    }
}