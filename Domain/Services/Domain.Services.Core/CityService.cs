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
    public class CityService : ServiceBase, ICityService
    {
        #region Constructor

        public CityService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<CityDto>> GetAllCities()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<CityDto>>>((response) =>
            {
                response.Result = Repository.All<City>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllCities' was unable to find any city records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<CityDto> FindCityById(Guid Id)
        {
            return TryExecute<GenericServiceResponse<CityDto>>((response) =>
            {
                response.Result = Repository.FindById<City>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindCityById' was unable to find the given city record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateCity(CityDto city)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(city.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateCity' was unable to insert a new city record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateCity(CityDto city)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(city.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateCity' was unable to update the given city record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteCity(CityDto city)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(city.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteCity' was unable to delete the given city record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteCity(Guid Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<City>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteCity' was unable to delete the given city record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}