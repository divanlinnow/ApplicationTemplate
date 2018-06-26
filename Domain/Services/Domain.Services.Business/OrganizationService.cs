using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Business;
using Domain.Mappings.Business;
using Domain.Models.Business;
using Domain.Services.Core;
using ORM.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Business
{
    public class OrganizationService : ServiceBase, IOrganizationService
    {
        #region Constructor

        public OrganizationService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<OrganizationDto>> GetAllOrganizations()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<OrganizationDto>>>((response) =>
            {
                response.Result = Repository.All<Organization>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllOrganizations' was unable to find any organization records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<OrganizationDto> FindOrganizationById(Guid Id)
        {
            return TryExecute<GenericServiceResponse<OrganizationDto>>((response) =>
            {
                response.Result = Repository.FindById<Organization>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindOrganizationById' was unable to find the given organization record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateOrganization(OrganizationDto organization)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(organization.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateOrganization' was unable to insert a new organization record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateOrganization(OrganizationDto organization)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(organization.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateOrganization' was unable to update the given organization record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteOrganization(OrganizationDto organization)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(organization.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteOrganization' was unable to delete the given organization record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteOrganization(Guid Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Organization>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteOrganization' was unable to delete the given organization record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}