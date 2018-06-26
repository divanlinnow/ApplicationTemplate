using Domain.Models.Business;
using Domain.Services.Core;
using System;
using System.Collections.Generic;

namespace Domain.Services.Business
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