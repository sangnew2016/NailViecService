using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class CountryRepository: ICountryRepository
    {
        private readonly GenericRepository<Country> _genericRepository;

        public CountryRepository(GenericRepository<Country> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        private NailViecAppContext Context { get { return _genericRepository.Context; } }

        public void Add(Country item)
        {
            _genericRepository.Add(item);
        }

        public void Delete(long id)
        {
            _genericRepository.Remove(GetById(id));
        }

        public void Update(Country item)
        {
            _genericRepository.Update(item);
        }

        public Country GetById(long id)
        {
            return Context.Countries.FirstOrDefault(p => p.Id == id);
        }

        public List<Country> GetAll()
        {
            return Context.Countries.ToList();
        }
    }
}
