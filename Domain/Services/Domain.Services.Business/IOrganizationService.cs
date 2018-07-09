using Domain.Models.Business;
using Domain.Services.Core;
using System.Collections.Generic;

namespace Domain.Services.Business
{
    public interface IOrganizationService
    {
        GenericServiceResponse<IEnumerable<OrganizationDto>> GetAllOrganizations();

        GenericServiceResponse<OrganizationDto> FindOrganizationById(int Id);

        GenericServiceResponse<bool> CreateOrganization(OrganizationDto organization);

        GenericServiceResponse<bool> UpdateOrganization(OrganizationDto organization);

        GenericServiceResponse<bool> DeleteOrganization(OrganizationDto organization);

        GenericServiceResponse<bool> DeleteOrganization(int Id);
    }
}