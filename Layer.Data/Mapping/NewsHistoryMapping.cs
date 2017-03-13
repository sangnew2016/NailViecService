using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class NewsHistoryMapping: BaseMapping<NewsHistory, long>
    {
        public NewsHistoryMapping() {
            Property(x => x.UpdatedDate).IsRequired();
        }
    }
}
