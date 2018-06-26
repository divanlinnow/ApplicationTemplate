using Domain.Models.Business;
using Domain.Services.Core;
using System;
using System.Collections.Generic;

namespace Domain.Services.Business
{
    public interface IEmployeeService
    {
        GenericServiceResponse<IEnumerable<EmployeeDto>> GetAllEmployees();

        GenericServiceResponse<EmployeeDto> FindEmployeeById(Guid Id);

        GenericServiceResponse<bool> CreateEmployee(EmployeeDto employee);

        GenericServiceResponse<bool> UpdateEmployee(EmployeeDto employee);

        GenericServiceResponse<bool> DeleteEmployee(EmployeeDto employee);

        GenericServiceResponse<bool> DeleteEmployee(Guid Id);
    }
}