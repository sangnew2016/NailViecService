using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class JobTypeRepository : BaseRepository<JobType>, IJobTypeRepository
    {
        public JobTypeRepository(GenericRepository<JobType> genericRepository) : base(genericRepository)
        {

        }
    }
}
