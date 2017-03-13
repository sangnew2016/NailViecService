using Layer.Domain.EntityBase;
using System;

namespace Layer.Domain.Entity
{
    public class NewsHistory: Entity<long>
    {
        public long NewsId { get; set; }
        public long NewsStatusId { get; set; }
        public DateTime UpdatedDate { get; set; }


        public News News { get; set; }
        public NewsStatus NewsStatus { get; set; }
    }
}
