using Layer.Domain.EntityBase;
using System.Collections.Generic;

namespace Layer.Domain.Repositories
{
    public interface IBaseRepository<T> where T: Entity<long>
    {
        void Add(T item);
        void Update(T item);
        void Delete(long id);
        T GetById(long id);
        List<T> GetAll();

    }
}
