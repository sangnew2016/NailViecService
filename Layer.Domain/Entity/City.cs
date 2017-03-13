using Layer.Domain.EntityBase;
using System.Collections.Generic;

namespace Layer.Domain.Entity
{
    public class City: SummaryJobEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public long StateId { get; set; }

        public State State { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
    }
}
