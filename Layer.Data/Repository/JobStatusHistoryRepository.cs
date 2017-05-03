using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class JobStatusHistoryRepository: BaseRepository<JobStatusHistory>, IJobStatusHistoryRepository
    {
        public JobStatusHistoryRepository(GenericRepository<JobStatusHistory> genericRepository) : base(genericRepository)
        {

        }

        public List<JobStatusHistory> GetAllByJobId(long jobId)
        {
            return Context.JobStatusHistories.Where(x => x.JobId == jobId).ToList();
        }
    }
}
