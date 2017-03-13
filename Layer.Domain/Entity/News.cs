using Layer.Domain.EntityBase;
using System.Collections.Generic;

namespace Layer.Domain.Entity
{
    public class News: Entity<long>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string PhoneContact { get; set; }
        public string Salary { get; set; }
        public string ImageUrl { get; set; }

        public NewsType NewsType { get; set; }

    }
}
