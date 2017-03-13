using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class NewsMapping: BaseMapping<News, long>
    {
        public NewsMapping() {
            Property(x => x.Title).IsRequired();
            Property(x => x.Body).IsRequired();
            Property(x => x.PhoneContact).IsRequired();
        }
    }
}
