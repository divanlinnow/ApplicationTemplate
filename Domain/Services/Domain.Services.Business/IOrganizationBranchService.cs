using Domain.Models.Business;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IOrganizationBranchService
    {
        GenericServiceResponse<IEnumerable<OrganizationBranchDto>> GetAllOrganizationBranches();

        GenericServiceResponse<OrganizationBranchDto> FindOrganizationBranchById(Guid Id);

        GenericServiceResponse<bool> CreateOrganizationBranch(OrganizationBranchDto organizationBranch);

        GenericServiceResponse<bool> UpdateOrganizationBranch(OrganizationBranchDto organizationBranch);

        GenericServiceResponse<bool> DeleteOrganizationBranch(OrganizationBranchDto organizationBranch);

        GenericServiceResponse<bool> DeleteOrganizationBranch(Guid Id);
    }
}