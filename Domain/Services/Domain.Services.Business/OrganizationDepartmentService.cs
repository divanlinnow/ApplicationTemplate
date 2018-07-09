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
    public class OrganizationDepartmentService : ServiceBase, IOrganizationDepartmentService
    {
        #region Constructor

        public OrganizationDepartmentService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<OrganizationDepartmentDto>> GetAllOrganizationDepartments()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<OrganizationDepartmentDto>>>((response) =>
            {
                response.Result = Repository.All<OrganizationDepartment>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllOrganizationDepartments' was unable to find any organizationDepartment records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<OrganizationDepartmentDto> FindOrganizationDepartmentById(int Id)
        {
            return TryExecute<GenericServiceResponse<OrganizationDepartmentDto>>((response) =>
            {
                response.Result = Repository.FindById<OrganizationDepartment>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindOrganizationDepartmentById' was unable to find the given organizationDepartment record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateOrganizationDepartment(OrganizationDepartmentDto organizationDepartment)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(organizationDepartment.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateOrganizationDepartment' was unable to insert a new organizationDepartment record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateOrganizationDepartment(OrganizationDepartmentDto organizationDepartment)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(organizationDepartment.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateOrganizationDepartment' was unable to update the given organizationDepartment record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteOrganizationDepartment(OrganizationDepartmentDto organizationDepartment)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(organizationDepartment.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteOrganizationDepartment' was unable to delete the given organizationDepartment record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteOrganizationDepartment(int Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<OrganizationDepartment>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteOrganizationDepartment' was unable to delete the given organizationDepartment record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}