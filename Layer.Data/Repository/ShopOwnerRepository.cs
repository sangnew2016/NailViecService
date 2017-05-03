using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class ShopOwnerRepository : BaseRepository<ShopOwner>, IShopOwnerRepository
    {
        public ShopOwnerRepository(GenericRepository<ShopOwner> genericRepository) : base(genericRepository)
        {

        }
    }
}
