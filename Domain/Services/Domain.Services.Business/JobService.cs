using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Business;
using Domain.Mappings.Business;
using Domain.Models.Business;
using Domain.Services.Core;
using ORM.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Business
{
    public class JobService : ServiceBase, IJobService
    {
        #region Constructor

        public JobService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<JobDto>> GetAllJobs()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<JobDto>>>((response) =>
            {
                response.Result = Repository.All<Job>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllJobs' was unable to find any job records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<JobDto> FindJobById(Guid Id)
        {
            return TryExecute<GenericServiceResponse<JobDto>>((response) =>
            {
                response.Result = Repository.FindById<Job>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindJobById' was unable to find the given job record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateJob(JobDto job)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(job.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateJob' was unable to insert a new job record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateJob(JobDto job)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(job.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateJob' was unable to update the given job record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteJob(JobDto job)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(job.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteJob' was unable to delete the given job record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteJob(Guid Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Job>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteJob' was unable to delete the given job record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}