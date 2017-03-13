using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Domain.EntityBase
{
    public abstract class Entity<TId>
    {
        public TId Id { get; protected set; }

        public byte[] RowVersion { get; protected set; }

    }


}
