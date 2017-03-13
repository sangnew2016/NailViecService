using Layer.Domain.EntityBase;
using System.Collections.Generic;

namespace Layer.Domain.Entity
{
    public class Country: SummaryJobEntity
    {
        protected Country()
        {
        }

        public Country(string name, string isoCode): this() {
            Name = name;
            Code = isoCode;
        }

        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
