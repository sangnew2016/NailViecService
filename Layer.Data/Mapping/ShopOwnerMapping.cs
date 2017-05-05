using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class ShopOwnerMapping: BaseMapping<ShopOwner, long>
    {
        public ShopOwnerMapping() {
            Property(x => x.FullName).IsRequired();
            Property(x => x.Phone).IsRequired();
            Property(x => x.Address).IsRequired();

            HasMany(x => x.Shops);

            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
