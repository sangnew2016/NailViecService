using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.EntityBase;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class BaseRepository<T>: IBaseRepository<T> where T: Entity<long>
    {
        private readonly GenericRepository<T> _genericRepository;

        public BaseRepository(GenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public NailViecAppContext Context { get { return _genericRepository.Context; } }

        public void Add(T item)
        {
            _genericRepository.Add(item);
        }

        public void Delete(long id)
        {
            _genericRepository.Remove(GetById(id));
        }

        public void Update(T item)
        {
            _genericRepository.Update(item);
        }

        public T GetById(long id)
        {
            return Context.Set<T>().AsQueryable().FirstOrDefault(p => p.Id == id);
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().AsQueryable().ToList();
        }
    }
}
