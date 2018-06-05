using Domain.Models.Business;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IOrderService
    {
        GenericServiceResponse<IEnumerable<OrderDto>> GetAllOrders();

        GenericServiceResponse<OrderDto> FindOrderById(Guid Id);

        GenericServiceResponse<bool> CreateOrder(OrderDto order);

        GenericServiceResponse<bool> UpdateOrder(OrderDto order);

        GenericServiceResponse<bool> DeleteOrder(OrderDto order);

        GenericServiceResponse<bool> DeleteOrder(Guid Id);
    }
}