using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Business;
using Domain.Mappings.Business;
using Domain.Models.Business;
using ORM.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Domain.Services.Core
{
    public class CurrencyService : ServiceBase, ICurrencyService
    {
        #region Constructor

        public CurrencyService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<CurrencyDto>> GetAllCurrencies()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<CurrencyDto>>>((response) =>
            {
                response.Result = Repository.All<Currency>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllCurrencies' was unable to find any currency records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<CurrencyDto> FindCurrencyById(Guid Id)
        {
            return TryExecute<GenericServiceResponse<CurrencyDto>>((response) =>
            {
                response.Result = Repository.FindById<Currency>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindCurrencyById' was unable to find the given currency record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateCurrency(CurrencyDto currency)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(currency.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateCurrency' was unable to insert a new currency record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateCurrency(CurrencyDto currency)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(currency.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateCurrency' was unable to update the given currency record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteCurrency(CurrencyDto currency)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(currency.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteCurrency' was unable to delete the given currency record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteCurrency(Guid Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Currency>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteCurrency' was unable to delete the given currency record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}