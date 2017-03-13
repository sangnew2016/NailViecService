using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class NewsStatusRepository: INewsStatusRepository
    {
        private readonly GenericRepository<NewsStatus> _genericRepository;

        public NewsStatusRepository(GenericRepository<NewsStatus> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        private NailViecAppContext Context { get { return _genericRepository.Context; } }

        public void Add(NewsStatus item)
        {
            _genericRepository.Add(item);
        }

        public void Delete(long id)
        {
            _genericRepository.Remove(GetById(id));
        }

        public void Update(NewsStatus item)
        {
            _genericRepository.Update(item);
        }

        public NewsStatus GetById(long id)
        {
            return Context.NewsStatus.FirstOrDefault(p => p.Id == id);
        }

        public List<NewsStatus> GetAll()
        {
            return Context.NewsStatus.ToList();
        }
    }
}
