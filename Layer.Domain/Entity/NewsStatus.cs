using Layer.Domain.EntityBase;
using System.Collections.Generic;

namespace Layer.Domain.Entity
{
    public class NewsStatus: Entity<long>
    {
        public string Name { get; set; }
        public bool IsShow { get; set; }

        public virtual ICollection<NewsHistory> NewsHistories { get; set; }
    }
}
