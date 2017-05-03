using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class ShopStatusHistoryMapping: BaseMapping<JobStatusHistory, long>
    {
        public ShopStatusHistoryMapping() {
            Property(x => x.UpdatedDate).IsRequired();
        }
    }
}
