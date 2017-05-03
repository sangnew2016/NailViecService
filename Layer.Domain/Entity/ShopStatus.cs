using Layer.Domain.EntityBase;
using System.Collections.Generic;

namespace Layer.Domain.Entity
{
    public class ShopStatus: Entity<long>
    {
        public string Name { get; set; }
        public bool IsShow { get; set; }

        public virtual ICollection<ShopStatusHistory> ShopStatusHistories { get; set; }
    }
}
