using FluentNHibernate.Mapping;
using FluentNHibernateDemo.Models;

namespace FluentNHibernateDemo.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Products");
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Name).Length(50).Not.Nullable();
            Map(p => p.Description).Length(150);
        }
    }
}