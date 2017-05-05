using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class JobMapping: BaseMapping<Job, long>
    {
        public JobMapping() {
            Property(x => x.Title).IsRequired();
            Property(x => x.Body).IsRequired();
            Property(x => x.PhoneContact).IsRequired();

            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
