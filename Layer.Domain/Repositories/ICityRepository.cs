using Layer.Domain.Entity;
using System.Collections.Generic;

namespace Layer.Domain.Repositories
{
    public interface ICityRepository
    {
        void Add(City item);
        void Update(City item);
        void Delete(long id);
        City GetById(long id);
        List<City> GetAll();

    }
}
