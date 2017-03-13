using Layer.Domain.Entity;
using System.Collections.Generic;

namespace Layer.Domain.Repositories
{
    public interface ICountryRepository
    {
        void Add(Country item);
        void Update(Country item);
        void Delete(long id);
        Country GetById(long id);
        List<Country> GetAll();

    }
}
