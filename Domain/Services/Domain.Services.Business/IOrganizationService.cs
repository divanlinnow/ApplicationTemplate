using Domain.Models.Business;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IOrganizationService
    {
        GenericServiceResponse<IEnumerable<OrganizationDto>> GetAllOrganizations();

        GenericServiceResponse<OrganizationDto> FindOrganizationById(Guid Id);

        GenericServiceResponse<bool> CreateOrganization(OrganizationDto organization);

        GenericServiceResponse<bool> UpdateOrganization(OrganizationDto organization);

        GenericServiceResponse<bool> DeleteOrganization(OrganizationDto organization);

        GenericServiceResponse<bool> DeleteOrganization(Guid Id);
    }
}