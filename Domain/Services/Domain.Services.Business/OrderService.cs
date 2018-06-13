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
    public class OrderService : ServiceBase, IOrderService
    {
        #region Constructor

        public OrderService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<OrderDto>> GetAllOrders()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<OrderDto>>>((response) =>
            {
                response.Result = Repository.All<Order>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllOrders' was unable to find any order records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<OrderDto> FindOrderById(Guid Id)
        {
            return TryExecute<GenericServiceResponse<OrderDto>>((response) =>
            {
                response.Result = Repository.FindById<Order>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindOrderById' was unable to find the given order record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateOrder(OrderDto order)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(order.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateOrder' was unable to insert a new order record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateOrder(OrderDto order)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(order.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateOrder' was unable to update the given order record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteOrder(OrderDto order)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(order.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteOrder' was unable to delete the given order record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteOrder(Guid Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Order>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteOrder' was unable to delete the given order record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}