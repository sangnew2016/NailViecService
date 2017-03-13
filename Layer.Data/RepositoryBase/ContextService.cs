using System.Data.Entity;

namespace Layer.Data.RepositoryBase
{
    public class ContextService
    {
        private readonly NailViecContextProvider _nailViecContextProvider;

        public ContextService(NailViecContextProvider nailViecContextProvider)
        {
            _nailViecContextProvider = nailViecContextProvider;
        }

        public bool HasChanges
        {
            get
            {
                return _nailViecContextProvider.Get().ChangeTracker.HasChanges();
            }
        }

        public int SaveChanges()
        {
            int count = _nailViecContextProvider.Get().SaveChanges();
            return count;
        }

        public DbContextTransaction BeginTransaction()
        {
            return _nailViecContextProvider.Get().Database.BeginTransaction();
        }
    }
}
