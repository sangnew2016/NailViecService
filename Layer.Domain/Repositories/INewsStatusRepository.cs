using Layer.Domain.Entity;
using System.Collections.Generic;

namespace Layer.Domain.Repositories
{
    public interface INewsStatusRepository
    {
        void Add(NewsStatus newsStatus);
        void Update(NewsStatus newsStatus);
        void Delete(long id);
        NewsStatus GetById(long id);
        List<NewsStatus> GetAll();

    }
}
