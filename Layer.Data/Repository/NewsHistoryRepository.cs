using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class NewsHistoryRepository: INewsHistoryRepository
    {
        private readonly GenericRepository<NewsHistory> _genericRepository;

        public NewsHistoryRepository(GenericRepository<NewsHistory> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        private NailViecAppContext Context { get { return _genericRepository.Context; } }

        public void Add(NewsHistory item)
        {
            _genericRepository.Add(item);
        }

        public void Delete(long id)
        {
            _genericRepository.Remove(GetById(id));
        }

        public void Update(NewsHistory item)
        {
            _genericRepository.Update(item);
        }

        public NewsHistory GetById(long id)
        {
            return Context.NewsHistories.FirstOrDefault(p => p.Id == id);
        }

        public List<NewsHistory> GetAll()
        {
            return Context.NewsHistories.ToList();
        }

        public List<NewsHistory> GetAllByNewsId(long newsId)
        {
            return Context.NewsHistories.Where(x => x.NewsId == newsId).ToList();
        }
    }
}
