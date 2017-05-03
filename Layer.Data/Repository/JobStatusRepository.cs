using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class JobStatusRepository: BaseRepository<JobStatus>, IJobStatusRepository
    {
        public JobStatusRepository(GenericRepository<JobStatus> genericRepository) : base(genericRepository)
        {

        }
    }
}
