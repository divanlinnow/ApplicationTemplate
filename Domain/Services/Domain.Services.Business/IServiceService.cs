using Domain.Models.Business;
using Domain.Services.Core;
using System.Collections.Generic;

namespace Domain.Services.Business
{
    public interface IServiceService
    {
        GenericServiceResponse<IEnumerable<ServiceDto>> GetAllServices();

        GenericServiceResponse<ServiceDto> FindServiceById(int Id);

        GenericServiceResponse<bool> CreateService(ServiceDto service);

        GenericServiceResponse<bool> UpdateService(ServiceDto service);

        GenericServiceResponse<bool> DeleteService(ServiceDto service);

        GenericServiceResponse<bool> DeleteService(int Id);
    }
}