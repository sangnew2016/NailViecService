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

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsHistory> NewsHistories { get; set; }
        public DbSet<NewsStatus> NewsStatus { get; set; }
        public DbSet<NewsType> NewsTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CountryMapping());
            modelBuilder.Configurations.Add(new StateMapping());
            modelBuilder.Configurations.Add(new CityMapping());
            modelBuilder.Configurations.Add(new ShopMapping());
            modelBuilder.Configurations.Add(new NewsMapping());
            modelBuilder.Configurations.Add(new NewsHistoryMapping());
            modelBuilder.Configurations.Add(new NewsStatusMapping());
            modelBuilder.Configurations.Add(new NewsTypeMapping());
        }
    }
}
