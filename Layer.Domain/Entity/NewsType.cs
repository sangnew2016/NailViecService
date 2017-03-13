using Layer.Domain.EntityBase;
using System.Collections.Generic;

namespace Layer.Domain.Entity
{
    public class NewsType: Entity<long>
    {
        public string Name { get; set; }
        public bool IsShow { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
