using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class JobStatusMapping: BaseMapping<JobStatus, long>
    {
        public JobStatusMapping() {
            Property(x => x.Name).IsRequired();
        }
    }
}
