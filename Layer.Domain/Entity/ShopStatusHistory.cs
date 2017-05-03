using Layer.Domain.EntityBase;
using System;

namespace Layer.Domain.Entity
{
    public class ShopStatusHistory: Entity<long>
    {
        public long ShopId { get; set; }
        public Shop Shop { get; set; }

        public long ShopStatusId { get; set; }
        public ShopStatus ShopStatus { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
