using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class NewsTypeRepository: INewsTypeRepository
    {
        private readonly GenericRepository<NewsType> _genericRepository;

        public NewsTypeRepository(GenericRepository<NewsType> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        private NailViecAppContext Context { get { return _genericRepository.Context; } }

        public void Add(NewsType item)
        {
            _genericRepository.Add(item);
        }

        public void Delete(long id)
        {
            _genericRepository.Remove(GetById(id));
        }

        public void Update(NewsType item)
        {
            _genericRepository.Update(item);
        }

        public NewsType GetById(long id)
        {
            return Context.NewsTypes.FirstOrDefault(p => p.Id == id);
        }

        public List<NewsType> GetAll()
        {
            return Context.NewsTypes.ToList();
        }
    }
}
