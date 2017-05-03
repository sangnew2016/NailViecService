using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class JobStatusHistoryMapping: BaseMapping<JobStatusHistory, long>
    {
        public JobStatusHistoryMapping() {
            Property(x => x.UpdatedDate).IsRequired();
        }
    }
}
