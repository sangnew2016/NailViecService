using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class ShopRepository: IShopRepository
    {
        private readonly GenericRepository<Shop> _genericRepository;

        public ShopRepository(GenericRepository<Shop> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        private NailViecAppContext Context { get { return _genericRepository.Context; } }

        public void Add(Shop item)
        {
            _genericRepository.Add(item);
        }

        public void Delete(long id)
        {
            _genericRepository.Remove(GetById(id));
        }

        public void Update(Shop item)
        {
            _genericRepository.Update(item);
        }

        public Shop GetById(long id)
        {
            return Context.Shops.FirstOrDefault(p => p.Id == id);
        }

        public List<Shop> GetAll()
        {
            return Context.Shops.ToList();
        }
    }
}
