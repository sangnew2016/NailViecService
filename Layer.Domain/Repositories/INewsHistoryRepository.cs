using Layer.Domain.Entity;
using System.Collections.Generic;

namespace Layer.Domain.Repositories
{
    public interface INewsHistoryRepository
    {
        void Add(NewsHistory newsHistory);
        void Update(NewsHistory newsHistory);
        void Delete(long id);
        NewsHistory GetById(long id);
        List<NewsHistory> GetAll();

        List<NewsHistory> GetAllByNewsId(long newsId);

    }
}
