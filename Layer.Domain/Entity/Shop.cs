using Layer.Domain.EntityBase;
using System;

namespace Layer.Domain.Entity
{
    public class Shop: Entity<long>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }



        public long ShopStatusId { get; set; }
        public ShopStatus ShopStatus { get; set; }

        public long PlaceId { get; set; }
        public Place Place { get; set; }

        public long ShopOwnerId { get; set; }
        public ShopOwner ShopOwner { get; set; }
    }
}
