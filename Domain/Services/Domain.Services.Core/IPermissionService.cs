using Domain.Models.Core;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IPermissionService
    {
        GenericServiceResponse<IEnumerable<PermissionDto>> GetAllPermissions();

        GenericServiceResponse<PermissionDto> FindPermissionById(Guid Id);

        GenericServiceResponse<bool> CreatePermission(PermissionDto permission);

        GenericServiceResponse<bool> UpdatePermission(PermissionDto permission);

        GenericServiceResponse<bool> DeletePermission(PermissionDto permission);

        GenericServiceResponse<bool> DeletePermission(Guid Id);
    }
}