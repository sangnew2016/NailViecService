using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class NewsTypeMapping: BaseMapping<NewsType, long>
    {
        public NewsTypeMapping() {
            Property(x => x.Name).IsRequired();
        }
    }
}
