using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class ShopMapping: BaseMapping<Shop, long>
    {
        public ShopMapping() {
            Property(x => x.Name).IsRequired();
            Property(x => x.Phone).IsRequired();
            Property(x => x.Address).IsRequired();

            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
