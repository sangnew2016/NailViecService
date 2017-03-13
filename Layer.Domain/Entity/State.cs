using Layer.Domain.EntityBase;
using System.Collections.Generic;

namespace Layer.Domain.Entity
{
    public class State: SummaryJobEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public long CountryId { get; set; }

        public Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
