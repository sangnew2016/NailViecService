using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class ShopStatusMapping: BaseMapping<ShopStatus, long>
    {
        public ShopStatusMapping() {
            Property(x => x.Name).IsRequired();

            HasMany(x => x.Shops);
            HasMany(x => x.ShopStatusHistories);
        }
    }
}
