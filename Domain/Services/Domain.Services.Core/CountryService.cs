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
    public class CountryService : ServiceBase, ICountryService
    {
        #region Constructor

        public CountryService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<CountryDto>> GetAllCountries()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<CountryDto>>>((response) =>
            {
                response.Result = Repository.All<Country>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllCountries' was unable to find any country records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<CountryDto> FindCountryById(int Id)
        {
            return TryExecute<GenericServiceResponse<CountryDto>>((response) =>
            {
                response.Result = Repository.FindById<Country>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindCountryById' was unable to find the given country record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateCountry(CountryDto country)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(country.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateCountry' was unable to insert a new country record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateCountry(CountryDto country)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(country.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateCountry' was unable to update the given country record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteCountry(CountryDto country)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(country.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteCountry' was unable to delete the given country record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteCountry(int Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Country>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteCountry' was unable to delete the given country record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}