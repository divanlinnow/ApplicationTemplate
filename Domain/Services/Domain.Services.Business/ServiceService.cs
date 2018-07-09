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
    public class ServiceService : ServiceBase, IServiceService
    {
        #region Constructor

        public ServiceService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<ServiceDto>> GetAllServices()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<ServiceDto>>>((response) =>
            {
                response.Result = Repository.All<Service>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllServices' was unable to find any service records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<ServiceDto> FindServiceById(int Id)
        {
            return TryExecute<GenericServiceResponse<ServiceDto>>((response) =>
            {
                response.Result = Repository.FindById<Service>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindServiceById' was unable to find the given service record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateService(ServiceDto service)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(service.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateService' was unable to insert a new service record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateService(ServiceDto service)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(service.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateService' was unable to update the given service record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteService(ServiceDto service)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(service.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteService' was unable to delete the given service record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteService(int Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Service>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteService' was unable to delete the given service record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}