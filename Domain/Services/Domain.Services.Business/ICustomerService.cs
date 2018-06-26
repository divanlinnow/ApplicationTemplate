using Domain.Models.Business;
using Domain.Services.Core;
using System;
using System.Collections.Generic;

namespace Domain.Services.Business
{
    public interface ICustomerService
    {
        GenericServiceResponse<IEnumerable<CustomerDto>> GetAllCustomers();

        GenericServiceResponse<CustomerDto> FindCustomerById(Guid Id);

        GenericServiceResponse<bool> CreateCustomer(CustomerDto customer);

        GenericServiceResponse<bool> UpdateCustomer(CustomerDto customer);

        GenericServiceResponse<bool> DeleteCustomer(CustomerDto customer);

        GenericServiceResponse<bool> DeleteCustomer(Guid Id);
    }
}