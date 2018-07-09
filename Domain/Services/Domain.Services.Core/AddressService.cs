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
    public class AddressService : ServiceBase, IAddressService
    {
        #region Constructor

        public AddressService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<AddressDto>> GetAllAddresses()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<AddressDto>>>((response) =>
            {
                response.Result = Repository.All<Address>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllAddresses' was unable to find any address records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<AddressDto> FindAddressById(int Id)
        {
            return TryExecute<GenericServiceResponse<AddressDto>>((response) =>
            {
                response.Result = Repository.FindById<Address>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindAddressById' was unable to find the given address record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateAddress(AddressDto address)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(address.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateAddress' was unable to insert a new address record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateAddress(AddressDto address)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(address.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateAddress' was unable to update the given address record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteAddress(AddressDto address)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(address.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteAddress' was unable to delete the given address record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteAddress(int Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Address>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteAddress' was unable to delete the given address record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}