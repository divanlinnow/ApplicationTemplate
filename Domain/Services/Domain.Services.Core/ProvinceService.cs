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
    public class ProvinceService : ServiceBase, IProvinceService
    {
        #region Constructor

        public ProvinceService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<ProvinceDto>> GetAllProvinces()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<ProvinceDto>>>((response) =>
            {
                response.Result = Repository.All<Province>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllProvinces' was unable to find any province records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<ProvinceDto> FindProvinceById(Guid Id)
        {
            return TryExecute<GenericServiceResponse<ProvinceDto>>((response) =>
            {
                response.Result = Repository.FindById<Province>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindProvinceById' was unable to find the given province record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateProvince(ProvinceDto province)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(province.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateProvince' was unable to insert a new province record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateProvince(ProvinceDto province)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(province.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateProvince' was unable to update the given province record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteProvince(ProvinceDto province)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(province.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteProvince' was unable to delete the given province record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteProvince(Guid Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Province>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteProvince' was unable to delete the given province record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}