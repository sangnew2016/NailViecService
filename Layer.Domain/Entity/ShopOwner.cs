using Layer.Domain.EntityBase;
using System;
using System.Collections.Generic;

namespace Layer.Domain.Entity
{
    public class ShopOwner: Entity<long>
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
    }
}
