using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class NewsStatusMapping: BaseMapping<NewsStatus, long>
    {
        public NewsStatusMapping() {
            Property(x => x.Name).IsRequired();
        }
    }
}
