using Domain.Models.Business;
using Domain.Services.Core;
using System.Collections.Generic;

namespace Domain.Services.Business
{
    public interface ITaskStatusService
    {
        GenericServiceResponse<IEnumerable<TaskStatusDto>> GetAllTaskStatuses();

        GenericServiceResponse<TaskStatusDto> FindTaskStatusById(int Id);

        GenericServiceResponse<bool> CreateTaskStatus(TaskStatusDto taskStatus);

        GenericServiceResponse<bool> UpdateTaskStatus(TaskStatusDto taskStatus);

        GenericServiceResponse<bool> DeleteTaskStatus(TaskStatusDto taskStatus);

        GenericServiceResponse<bool> DeleteTaskStatus(int Id);
    }
}