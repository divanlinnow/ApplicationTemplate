using Domain.Models.Business;
using Domain.Services.Core;
using System.Collections.Generic;

namespace Domain.Services.Business
{
    public interface IEmployeeService
    {
        GenericServiceResponse<IEnumerable<EmployeeDto>> GetAllEmployees();

        GenericServiceResponse<EmployeeDto> FindEmployeeById(int Id);

        GenericServiceResponse<bool> CreateEmployee(EmployeeDto employee);

        GenericServiceResponse<bool> UpdateEmployee(EmployeeDto employee);

        GenericServiceResponse<bool> DeleteEmployee(EmployeeDto employee);

        GenericServiceResponse<bool> DeleteEmployee(int Id);
    }
}