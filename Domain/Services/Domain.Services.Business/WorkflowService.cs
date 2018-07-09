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
    public class WorkflowService : ServiceBase, IWorkflowService
    {
        #region Constructor

        public WorkflowService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<WorkflowDto>> GetAllWorkflows()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<WorkflowDto>>>((response) =>
            {
                response.Result = Repository.All<Workflow>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllWorkflows' was unable to find any workflow records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<WorkflowDto> FindWorkflowById(int Id)
        {
            return TryExecute<GenericServiceResponse<WorkflowDto>>((response) =>
            {
                response.Result = Repository.FindById<Workflow>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindWorkflowById' was unable to find the given workflow record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateWorkflow(WorkflowDto workflow)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(workflow.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateWorkflow' was unable to insert a new workflow record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateWorkflow(WorkflowDto workflow)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(workflow.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateWorkflow' was unable to update the given workflow record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteWorkflow(WorkflowDto workflow)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(workflow.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteWorkflow' was unable to delete the given workflow record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteWorkflow(int Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Workflow>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteWorkflow' was unable to delete the given workflow record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}