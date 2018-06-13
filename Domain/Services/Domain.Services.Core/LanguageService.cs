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
    public class LanguageService : ServiceBase, ILanguageService
    {
        #region Constructor

        public LanguageService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<LanguageDto>> GetAllLanguages()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<LanguageDto>>>((response) =>
            {
                response.Result = Repository.All<Language>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllLanguages' was unable to find any language records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<LanguageDto> FindLanguageById(Guid Id)
        {
            return TryExecute<GenericServiceResponse<LanguageDto>>((response) =>
            {
                response.Result = Repository.FindById<Language>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindLanguageById' was unable to find the given language record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateLanguage(LanguageDto language)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(language.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateLanguage' was unable to insert a new language record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateLanguage(LanguageDto language)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(language.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateLanguage' was unable to update the given language record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteLanguage(LanguageDto language)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(language.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteLanguage' was unable to delete the given language record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteLanguage(Guid Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Language>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteLanguage' was unable to delete the given language record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}