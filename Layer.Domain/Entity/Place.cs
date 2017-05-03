using Layer.Domain.EntityBase;
using System.Collections.Generic;

namespace Layer.Domain.Entity
{
    public class Place: SummaryJobEntity
    {
        protected Place()
        {
        }

        public Place(string code): this() {
            Code = code;
        }

        public string Code { get; set; }
        public string FullAddress { get; set; }
        public string Latitude { get; set; }
        public string Longtitude { get; set; }
        public string AreaName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }

    }
}
