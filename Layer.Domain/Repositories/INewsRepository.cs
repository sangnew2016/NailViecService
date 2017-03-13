using Layer.Domain.Entity;
using System.Collections.Generic;

namespace Layer.Domain.Repositories
{
    public interface INewsRepository
    {
        void Add(News news);
        void Update(News news);
        void Delete(long id);
        News GetById(long id);
        List<News> GetAll();

    }
}
