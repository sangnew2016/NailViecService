using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class NewsRepository: INewsRepository
    {
        private readonly GenericRepository<News> _genericRepository;

        public NewsRepository(GenericRepository<News> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        private NailViecAppContext Context { get { return _genericRepository.Context; } }

        public void Add(News item)
        {
            _genericRepository.Add(item);
        }

        public void Delete(long id)
        {
            _genericRepository.Remove(GetById(id));
        }

        public void Update(News item)
        {
            _genericRepository.Update(item);
        }

        public News GetById(long id)
        {
            return Context.News.FirstOrDefault(p => p.Id == id);
        }

        public List<News> GetAll()
        {
            return Context.News.ToList();
        }
    }
}
