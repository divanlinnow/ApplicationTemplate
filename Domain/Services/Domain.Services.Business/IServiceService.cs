using Domain.Models.Business;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IServiceService
    {
        GenericServiceResponse<IEnumerable<ServiceDto>> GetAllServices();

        GenericServiceResponse<ServiceDto> FindServiceById(Guid Id);

        GenericServiceResponse<bool> CreateService(ServiceDto service);

        GenericServiceResponse<bool> UpdateService(ServiceDto service);

        GenericServiceResponse<bool> DeleteService(ServiceDto service);

        GenericServiceResponse<bool> DeleteService(Guid Id);
    }
}