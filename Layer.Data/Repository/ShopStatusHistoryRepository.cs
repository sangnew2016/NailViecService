using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class ShopStatusHistoryRepository : BaseRepository<ShopStatusHistory>, IShopStatusHistoryRepository
    {
        public ShopStatusHistoryRepository(GenericRepository<ShopStatusHistory> genericRepository) : base(genericRepository)
        {

        }

        public List<ShopStatusHistory> GetAllByShopId(long shopId) {
            var list = Context.ShopStatusHistories.Where(p => p.ShopId == shopId).ToList();
            return list;
        }
    }
}
