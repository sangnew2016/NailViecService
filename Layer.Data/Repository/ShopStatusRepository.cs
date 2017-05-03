using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class ShopStatusRepository : BaseRepository<ShopStatus>, IShopStatusRepository
    {
        public ShopStatusRepository(GenericRepository<ShopStatus> genericRepository) : base(genericRepository)
        {

        }
    }
}
