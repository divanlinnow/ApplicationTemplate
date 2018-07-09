using Domain.Models.Business;
using Domain.Services.Core;
using System.Collections.Generic;

namespace Domain.Services.Business
{
    public interface IJobService
    {
        GenericServiceResponse<IEnumerable<JobDto>> GetAllJobs();

        GenericServiceResponse<JobDto> FindJobById(int Id);

        GenericServiceResponse<bool> CreateJob(JobDto job);

        GenericServiceResponse<bool> UpdateJob(JobDto job);

        GenericServiceResponse<bool> DeleteJob(JobDto job);

        GenericServiceResponse<bool> DeleteJob(int Id);
    }
}