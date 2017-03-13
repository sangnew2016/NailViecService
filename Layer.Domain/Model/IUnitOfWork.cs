using System;

namespace Layer.Domain.Model
{
    public interface IUnitOfWork : IDisposable
    {
        int SavePoint();

        void Commit();
        void Rollback();
    }
}
