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
    public class SupplierService : ServiceBase, ISupplierService
    {
        #region Constructor

        public SupplierService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<SupplierDto>> GetAllSuppliers()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<SupplierDto>>>((response) =>
            {
                response.Result = Repository.All<Supplier>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllSuppliers' was unable to find any supplier records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<SupplierDto> FindSupplierById(int Id)
        {
            return TryExecute<GenericServiceResponse<SupplierDto>>((response) =>
            {
                response.Result = Repository.FindById<Supplier>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindSupplierById' was unable to find the given supplier record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateSupplier(SupplierDto supplier)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(supplier.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateSupplier' was unable to insert a new supplier record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateSupplier(SupplierDto supplier)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(supplier.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateSupplier' was unable to update the given supplier record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteSupplier(SupplierDto supplier)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(supplier.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteSupplier' was unable to delete the given supplier record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteSupplier(int Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Supplier>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteSupplier' was unable to delete the given supplier record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}