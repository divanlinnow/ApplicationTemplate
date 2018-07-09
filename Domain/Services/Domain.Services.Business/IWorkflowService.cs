using Domain.Models.Business;
using Domain.Services.Core;
using System.Collections.Generic;

namespace Domain.Services.Business
{
    public interface IWorkflowService
    {
        GenericServiceResponse<IEnumerable<WorkflowDto>> GetAllWorkflows();

        GenericServiceResponse<WorkflowDto> FindWorkflowById(int Id);

        GenericServiceResponse<bool> CreateWorkflow(WorkflowDto workflow);

        GenericServiceResponse<bool> UpdateWorkflow(WorkflowDto workflow);

        GenericServiceResponse<bool> DeleteWorkflow(WorkflowDto workflow);

        GenericServiceResponse<bool> DeleteWorkflow(int Id);
    }
}