namespace Layer.Domain.EntityBase
{
    public class SummaryJobEntity: Entity<long>
    {
        public double TotalJobs { get; set; }
        public double TotalShops { get; set; }
    }
}
