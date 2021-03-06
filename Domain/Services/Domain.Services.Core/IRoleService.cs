﻿using Domain.Models.Core;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IRoleService
    {
        GenericServiceResponse<IEnumerable<RoleDto>> GetAllRoles();

        GenericServiceResponse<RoleDto> FindRoleById(int Id);

        GenericServiceResponse<bool> CreateRole(RoleDto role);

        GenericServiceResponse<bool> UpdateRole(RoleDto role);

        GenericServiceResponse<bool> DeleteRole(RoleDto role);

        GenericServiceResponse<bool> DeleteRole(int Id);
    }
}