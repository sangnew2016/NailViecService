﻿using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class ShopRepository : BaseRepository<Shop>, IShopRepository
    {
        public ShopRepository(GenericRepository<Shop> genericRepository) : base(genericRepository)
        {

        }
    }
}
