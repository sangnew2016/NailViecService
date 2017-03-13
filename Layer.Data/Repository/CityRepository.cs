using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class CityRepository: ICityRepository
    {
        private readonly GenericRepository<City> _genericRepository;

        public CityRepository(GenericRepository<City> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        private NailViecAppContext Context { get { return _genericRepository.Context; } }

        public void Add(City item)
        {
            _genericRepository.Add(item);
        }

        public void Delete(long id)
        {
            _genericRepository.Remove(GetById(id));
        }

        public void Update(City item)
        {
            _genericRepository.Update(item);
        }

        public City GetById(long id)
        {
            return Context.Cities.FirstOrDefault(p => p.Id == id);
        }

        public List<City> GetAll()
        {
            return Context.Cities.ToList();
        }
    }
}
