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
    public class CustomerService : ServiceBase, ICustomerService
    {
        #region Constructor

        public CustomerService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<CustomerDto>>>((response) =>
            {
                response.Result = Repository.All<Customer>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllCustomers' was unable to find any customer records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<CustomerDto> FindCustomerById(Guid Id)
        {
            return TryExecute<GenericServiceResponse<CustomerDto>>((response) =>
            {
                response.Result = Repository.FindById<Customer>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindCustomerById' was unable to find the given customer record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateCustomer(CustomerDto customer)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(customer.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateCustomer' was unable to insert a new customer record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateCustomer(CustomerDto customer)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(customer.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateCustomer' was unable to update the given customer record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteCustomer(CustomerDto customer)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(customer.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteCustomer' was unable to delete the given customer record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteCustomer(Guid Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Customer>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteCustomer' was unable to delete the given customer record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}