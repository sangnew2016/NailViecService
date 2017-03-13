using Layer.Domain.Entity;

namespace Layer.Data.Mapping
{
    public class StateMapping: BaseMapping<State, long>
    {
        public StateMapping() {
            Property(x => x.Code).IsRequired();
            Property(x => x.Name).IsRequired();
            //HasMany(x => x.Cities).WithRequired().HasForeignKey(x => x.StateId).WillCascadeOnDelete();
        }
    }
}
