using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Core;
using Domain.Mappings.Core;
using Domain.Models.Core;
using ORM.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Domain.Services.Core
{
    public class RoleService : ServiceBase, IRoleService
    {
        #region Constructor

        public RoleService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<RoleDto>> GetAllRoles()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<RoleDto>>>((response) =>
            {
                response.Result = Repository.All<Role>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllRoles' was unable to find any role records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<RoleDto> FindRoleById(Guid Id)
        {
            return TryExecute<GenericServiceResponse<RoleDto>>((response) =>
            {
                response.Result = Repository.FindById<Role>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindRoleById' was unable to find the given role record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateRole(RoleDto role)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(role.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateRole' was unable to insert a new role record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateRole(RoleDto role)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(role.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateRole' was unable to update the given role record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteRole(RoleDto role)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(role.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteRole' was unable to delete the given role record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteRole(Guid Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Role>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteRole' was unable to delete the given role record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}