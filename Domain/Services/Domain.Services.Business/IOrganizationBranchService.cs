using Domain.Models.Business;
using Domain.Services.Core;
using System.Collections.Generic;

namespace Domain.Services.Business
{
    public interface IOrganizationBranchService
    {
        GenericServiceResponse<IEnumerable<OrganizationBranchDto>> GetAllOrganizationBranches();

        GenericServiceResponse<OrganizationBranchDto> FindOrganizationBranchById(int Id);

        GenericServiceResponse<bool> CreateOrganizationBranch(OrganizationBranchDto organizationBranch);

        GenericServiceResponse<bool> UpdateOrganizationBranch(OrganizationBranchDto organizationBranch);

        GenericServiceResponse<bool> DeleteOrganizationBranch(OrganizationBranchDto organizationBranch);

        GenericServiceResponse<bool> DeleteOrganizationBranch(int Id);
    }
}