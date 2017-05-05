using Layer.Domain.EntityBase;
using System;

namespace Layer.Domain.Entity
{
    public class JobStatusHistory: Entity<long>
    {
        public long JobId { get; set; }        

        public long JobStatusId { get; set; }        

        public DateTime UpdatedDate { get; set; }

    }
}
