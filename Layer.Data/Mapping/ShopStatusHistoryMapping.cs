using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class ShopStatusHistoryMapping: BaseMapping<ShopStatusHistory, long>
    {
        public ShopStatusHistoryMapping() {
            Property(x => x.UpdatedDate).IsRequired();
        }
    }
}
