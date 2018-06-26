using Domain.ServiceProvider.Core;
using Domain.Services.Business;

namespace Domain.ServiceProvider.Business
{
    public interface IServiceProviderBusiness : IBaseServiceProvider
    {
        ICurrencyService CurrencyService { get; }

        ICustomerService CustomerService { get; }

        IEmployeeService EmployeeService { get; }

        IJobService JobService { get; }

        IOrderService OrderService { get; }

        IOrganizationBranchService OrganizationBranchService { get; }

        IOrganizationDepartmentService OrganizationDepartmentService { get; }

        IOrganizationService OrganizationService { get; }

        IProductService ProductService { get; }

        IServiceService ServiceService { get; }

        ISupplierService SupplierService { get; }

        ITaskService TaskService { get; }
        
        IWorkflowService WorkflowService { get; }
    }
}
