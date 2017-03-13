using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class CityMapping: BaseMapping<City, long>
    {
        public CityMapping() {
            Property(x => x.Code).IsRequired();
            Property(x => x.Name).IsRequired();
            //HasMany(x => x.Shops).WithRequired().HasForeignKey(x => x.CityId).WillCascadeOnDelete();
        }
    }
}
