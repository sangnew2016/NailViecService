using Layer.Domain.EntityBase;
using System.Collections.Generic;

namespace Layer.Domain.Entity
{
    public class Job: Entity<long>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string PhoneContact { get; set; }
        public string Salary { get; set; }
        public string ImageUrl { get; set; }

        public long JobId { get; set; }
        public JobType JobType { get; set; }

        public long JobStatusId { get; set; }
        public JobStatus JobStatus { get; set; }
    }
}
