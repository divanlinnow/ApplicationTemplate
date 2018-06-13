using Domain.Models.Business;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface ITaskStatusService
    {
        GenericServiceResponse<IEnumerable<TaskStatusDto>> GetAllTaskStatuses();

        GenericServiceResponse<TaskStatusDto> FindTaskStatusById(Guid Id);

        GenericServiceResponse<bool> CreateTaskStatus(TaskStatusDto taskStatus);

        GenericServiceResponse<bool> UpdateTaskStatus(TaskStatusDto taskStatus);

        GenericServiceResponse<bool> DeleteTaskStatus(TaskStatusDto taskStatus);

        GenericServiceResponse<bool> DeleteTaskStatus(Guid Id);
    }
}