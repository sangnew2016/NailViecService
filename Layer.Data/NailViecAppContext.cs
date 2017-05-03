using Layer.Data.Mapping;
using Layer.Domain.Entity;
using System.Data.Entity;

namespace Layer.Data
{
    public class NailViecAppContext: DbContext
    {
        public NailViecAppContext() : base("NailViecAppContext") {
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NailViecAppContext, Migrations.Configuration>());
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopStatus> ShopStatus { get; set; }
        public DbSet<ShopStatusHistory> ShopStatusHistories { get; set; }
        public DbSet<ShopOwner> ShopOwners { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobStatusHistory> JobStatusHistories { get; set; }
        public DbSet<JobStatus> JobStatus { get; set; }
        public DbSet<JobType> JobTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ShopMapping());
            modelBuilder.Configurations.Add(new ShopStatusHistoryMapping());
            modelBuilder.Configurations.Add(new ShopStatusMapping());
            modelBuilder.Configurations.Add(new ShopOwnerMapping());

            modelBuilder.Configurations.Add(new JobMapping());
            modelBuilder.Configurations.Add(new JobStatusHistoryMapping());
            modelBuilder.Configurations.Add(new JobStatusMapping());
            modelBuilder.Configurations.Add(new JobTypeMapping());
        }
    }
}
