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
    public class PermissionService : ServiceBase, IPermissionService
    {
        #region Constructor

        public PermissionService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<PermissionDto>> GetAllPermissions()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<PermissionDto>>>((response) =>
            {
                response.Result = Repository.All<Permission>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllPermissions' was unable to find any permission records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<PermissionDto> FindPermissionById(Guid Id)
        {
            return TryExecute<GenericServiceResponse<PermissionDto>>((response) =>
            {
                response.Result = Repository.FindById<Permission>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindPermissionById' was unable to find the given permission record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreatePermission(PermissionDto permission)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(permission.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreatePermission' was unable to insert a new permission record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdatePermission(PermissionDto permission)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(permission.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdatePermission' was unable to update the given permission record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeletePermission(PermissionDto permission)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(permission.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeletePermission' was unable to delete the given permission record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeletePermission(Guid Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Permission>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeletePermission' was unable to delete the given permission record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}