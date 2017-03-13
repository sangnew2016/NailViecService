using Layer.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Layer.Data.Mapping
{
    public class CountryMapping: BaseMapping<Country, long>
    {
        public CountryMapping() {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Code).IsRequired();
            Property(x => x.Name).IsRequired();
            //HasMany(x => x.States).WithRequired().HasForeignKey(x => x.CountryId).WillCascadeOnDelete();
        }
    }
}
