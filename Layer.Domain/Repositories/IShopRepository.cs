using Layer.Domain.Entity;
using System.Collections.Generic;

namespace Layer.Domain.Repositories
{
    public interface IShopRepository
    {
        void Add(Shop shop);
        void Update(Shop shop);
        void Delete(long id);
        Shop GetById(long id);
        List<Shop> GetAll();

    }
}
