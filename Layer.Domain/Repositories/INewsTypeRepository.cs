using Layer.Domain.Entity;
using System.Collections.Generic;

namespace Layer.Domain.Repositories
{
    public interface INewsTypeRepository
    {
        void Add(NewsType newsType);
        void Update(NewsType newsType);
        void Delete(long id);
        NewsType GetById(long id);
        List<NewsType> GetAll();

    }
}
