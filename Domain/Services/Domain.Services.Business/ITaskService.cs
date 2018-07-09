using Domain.Models.Business;
using Domain.Services.Core;
using System.Collections.Generic;

namespace Domain.Services.Business
{
    public interface ITaskService
    {
        GenericServiceResponse<IEnumerable<TaskDto>> GetAllTasks();

        GenericServiceResponse<TaskDto> FindTaskById(int Id);

        GenericServiceResponse<bool> CreateTask(TaskDto task);

        GenericServiceResponse<bool> UpdateTask(TaskDto task);

        GenericServiceResponse<bool> DeleteTask(TaskDto task);

        GenericServiceResponse<bool> DeleteTask(int Id);
    }
}