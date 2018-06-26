using Domain.Models.Business;
using Domain.Services.Core;
using System;
using System.Collections.Generic;

namespace Domain.Services.Business
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