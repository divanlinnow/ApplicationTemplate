using Domain.Models.Business;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
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