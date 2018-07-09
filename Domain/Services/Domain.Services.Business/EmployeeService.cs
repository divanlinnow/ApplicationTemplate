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
    public class EmployeeService : ServiceBase, IEmployeeService
    {
        #region Constructor

        public EmployeeService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<EmployeeDto>>>((response) =>
            {
                response.Result = Repository.All<Employee>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllEmployees' was unable to find any employee records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<EmployeeDto> FindEmployeeById(int Id)
        {
            return TryExecute<GenericServiceResponse<EmployeeDto>>((response) =>
            {
                response.Result = Repository.FindById<Employee>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindEmployeeById' was unable to find the given employee record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateEmployee(EmployeeDto employee)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(employee.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateEmployee' was unable to insert a new employee record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateEmployee(EmployeeDto employee)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(employee.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateEmployee' was unable to update the given employee record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteEmployee(EmployeeDto employee)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(employee.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteEmployee' was unable to delete the given employee record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteEmployee(int Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<Employee>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteEmployee' was unable to delete the given employee record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}