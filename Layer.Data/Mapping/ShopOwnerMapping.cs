using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class ShopOwnerMapping: BaseMapping<Shop, long>
    {
        public ShopOwnerMapping() {
            Property(x => x.Name).IsRequired();
            Property(x => x.Phone).IsRequired();
            Property(x => x.Address).IsRequired();
        }
    }
}
