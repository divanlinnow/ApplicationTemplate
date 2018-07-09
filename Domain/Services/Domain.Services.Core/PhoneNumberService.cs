using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Core;
using Domain.Mappings.Core;
using Domain.Models.Core;
using ORM.EF.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Core
{
    public class PhoneNumberService : ServiceBase, IPhoneNumberService
    {
        #region Constructor

        public PhoneNumberService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<PhoneNumberDto>> GetAllPhoneNumbers()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<PhoneNumberDto>>>((response) =>
            {
                response.Result = Repository.All<PhoneNumber>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllPhoneNumbers' was unable to find any phoneNumber records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<PhoneNumberDto> FindPhoneNumberById(int Id)
        {
            return TryExecute<GenericServiceResponse<PhoneNumberDto>>((response) =>
            {
                response.Result = Repository.FindById<PhoneNumber>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindPhoneNumberById' was unable to find the given phoneNumber record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreatePhoneNumber(PhoneNumberDto phoneNumber)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(phoneNumber.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreatePhoneNumber' was unable to insert a new phoneNumber record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdatePhoneNumber(PhoneNumberDto phoneNumber)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(phoneNumber.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdatePhoneNumber' was unable to update the given phoneNumber record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeletePhoneNumber(PhoneNumberDto phoneNumber)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(phoneNumber.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeletePhoneNumber' was unable to delete the given phoneNumber record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeletePhoneNumber(int Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<PhoneNumber>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeletePhoneNumber' was unable to delete the given phoneNumber record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}