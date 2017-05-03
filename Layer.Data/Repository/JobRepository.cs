using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class JobRepository: BaseRepository<Job>, IJobRepository
    {
        public JobRepository(GenericRepository<Job> genericRepository) : base(genericRepository)
        {

        }
    }
}
