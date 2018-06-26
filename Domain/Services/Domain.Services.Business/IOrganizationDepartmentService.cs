using Domain.Models.Business;
using Domain.Services.Core;
using System;
using System.Collections.Generic;

namespace Domain.Services.Business
{
    public interface IOrganizationDepartmentService
    {
        GenericServiceResponse<IEnumerable<OrganizationDepartmentDto>> GetAllOrganizationDepartments();

        GenericServiceResponse<OrganizationDepartmentDto> FindOrganizationDepartmentById(Guid Id);

        GenericServiceResponse<bool> CreateOrganizationDepartment(OrganizationDepartmentDto organizationDepartment);

        GenericServiceResponse<bool> UpdateOrganizationDepartment(OrganizationDepartmentDto organizationDepartment);

        GenericServiceResponse<bool> DeleteOrganizationDepartment(OrganizationDepartmentDto organizationDepartment);

        GenericServiceResponse<bool> DeleteOrganizationDepartment(Guid Id);
    }
}