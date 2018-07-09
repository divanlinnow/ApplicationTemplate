using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Business;
using Domain.Mappings.Business;
using Domain.Models.Business;
using Domain.Services.Core;
using ORM.EF.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Business
{
    public class TaskService : ServiceBase, ITaskService
    {
        #region Constructor

        public TaskService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<TaskDto>> GetAllTasks()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<TaskDto>>>((response) =>
            {
                response.Result = Repository.All<Task>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllTasks' was unable to find any task records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<TaskDto> FindTaskById(int Id)
        {
            return TryExecute<GenericServiceResponse<TaskDto>>((response) =>
            {
                response.Result = Repository.FindById<Task>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindTaskById' was unable to find the given task record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateTask(TaskDto task)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(task.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateTask' was unable to insert a new task record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateTask(TaskDto task)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(task.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateTask' was unable to update the given task record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteTask(TaskDto task)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(task.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteTask' was unable to delete the given task record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteTask(int Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Task>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteTask' was unable to delete the given task record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}