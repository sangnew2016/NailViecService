using Layer.Domain.EntityBase;
using System.Collections.Generic;

namespace Layer.Domain.Entity
{
    public class JobStatus: Entity<long>
    {
        public string Name { get; set; }
        public bool IsShow { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<JobStatusHistory> JobStatusHistories { get; set; }
    }
}
