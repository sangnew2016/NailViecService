using Layer.Domain.Entity;
using System.Collections.Generic;

namespace Layer.Domain.Repositories
{
    public interface IJobStatusHistoryRepository: IBaseRepository<JobStatusHistory>
    {
        List<JobStatusHistory> GetAllByJobId(long jobId);
    }
}
