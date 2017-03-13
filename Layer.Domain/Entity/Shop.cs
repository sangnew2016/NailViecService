using Layer.Domain.EntityBase;
using System;

namespace Layer.Domain.Entity
{
    public class Shop: Entity<long>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
        public Guid UserId { get; set; }
        public long CityId { get; set; }

        //public User User { get; set; }
        public City City { get; set; }
    }
}
