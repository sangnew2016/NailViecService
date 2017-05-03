using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class PlaceRepository : BaseRepository<Place>, IPlaceRepository
    {
        public PlaceRepository(GenericRepository<Place> genericRepository) : base(genericRepository)
        {

        }
    }
}
