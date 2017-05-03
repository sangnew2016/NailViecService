using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class JobTypeMapping: BaseMapping<JobType, long>
    {
        public JobTypeMapping() {
            Property(x => x.Name).IsRequired();
        }
    }
}
