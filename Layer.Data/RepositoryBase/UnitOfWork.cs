using Layer.Domain.Model;
using System;
using System.Data.Entity;

namespace Layer.Data.RepositoryBase
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextService _contextService;

        private DbContextTransaction Transaction { get; set; }

        public UnitOfWork(ContextService contextService)
        {
            _contextService = contextService;
        }

        public int SavePoint()
        {
            return _contextService.SaveChanges();
        }

        public IUnitOfWork Begin()
        {
            if (Transaction != null) throw new InvalidOperationException("Transaction already started");
            Transaction = _contextService.BeginTransaction();
            return this;
        }

        public void Commit()
        {
            if (Transaction != null)
            {
                SavePoint();
                Transaction.Commit();
                Transaction = null;
            }
        }

        public void Rollback()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction = null;
            }
        }


        public void Dispose()
        {
            Rollback();
        }
    }
}
