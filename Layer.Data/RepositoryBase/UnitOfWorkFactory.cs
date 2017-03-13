using Layer.Domain.Model;

namespace Layer.Data.RepositoryBase
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ContextService _contextService;

        public UnitOfWorkFactory(ContextService contextService)
        {
            _contextService = contextService;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_contextService).Begin();
        }
    }
}
