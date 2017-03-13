using Layer.Domain.EntityBase;
using System.Data.Entity.ModelConfiguration;

namespace Layer.Data.Mapping
{
    public class BaseMapping<TEntity, TId>: EntityTypeConfiguration<TEntity> where TEntity: Entity<TId>
    {
        public BaseMapping() {
            HasKey(x => x.Id);
            Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
