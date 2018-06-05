using Domain.Models.Business;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface ITaskService
    {
        GenericServiceResponse<IEnumerable<TaskDto>> GetAllTasks();

        GenericServiceResponse<TaskDto> FindTaskById(Guid Id);

        GenericServiceResponse<bool> CreateTask(TaskDto task);

        GenericServiceResponse<bool> UpdateTask(TaskDto task);

        GenericServiceResponse<bool> DeleteTask(TaskDto task);

        GenericServiceResponse<bool> DeleteTask(Guid Id);
    }
}