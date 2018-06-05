using Domain.Models.Business;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IJobService
    {
        GenericServiceResponse<IEnumerable<JobDto>> GetAllJobs();

        GenericServiceResponse<JobDto> FindJobById(Guid Id);

        GenericServiceResponse<bool> CreateJob(JobDto job);

        GenericServiceResponse<bool> UpdateJob(JobDto job);

        GenericServiceResponse<bool> DeleteJob(JobDto job);

        GenericServiceResponse<bool> DeleteJob(Guid Id);
    }
}