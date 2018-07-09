using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Business;
using Domain.Mappings.Business;
using Domain.Models.Business;
using Domain.Services.Core;
using ORM.EF.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Business
{
    public class OrganizationBranchService : ServiceBase, IOrganizationBranchService
    {
        #region Constructor

        public OrganizationBranchService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<OrganizationBranchDto>> GetAllOrganizationBranches()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<OrganizationBranchDto>>>((response) =>
            {
                response.Result = Repository.All<OrganizationBranch>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllOrganizationBranches' was unable to find any organizationBranch records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<OrganizationBranchDto> FindOrganizationBranchById(int Id)
        {
            return TryExecute<GenericServiceResponse<OrganizationBranchDto>>((response) =>
            {
                response.Result = Repository.FindById<OrganizationBranch>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindOrganizationBranchById' was unable to find the given organizationBranch record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateOrganizationBranch(OrganizationBranchDto organizationBranch)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(organizationBranch.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateOrganizationBranch' was unable to insert a new organizationBranch record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateOrganizationBranch(OrganizationBranchDto organizationBranch)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(organizationBranch.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateOrganizationBranch' was unable to update the given organizationBranch record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteOrganizationBranch(OrganizationBranchDto organizationBranch)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(organizationBranch.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteOrganizationBranch' was unable to delete the given organizationBranch record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteOrganizationBranch(int Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<OrganizationBranch>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteOrganizationBranch' was unable to delete the given organizationBranch record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}