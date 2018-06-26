using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Telemetry;
using Domain.Services.Business;
using System;
using Unity;
using Unity.Attributes;

namespace Domain.ServiceProvider.Business
{
    public class ServiceProviderBusiness : IServiceProviderBusiness
    {
        private bool disposed;

        [Dependency]
        protected IUnityContainer Container { get; set; }

        [Dependency]
        public ILogger Logger { get; set; }

        [Dependency]
        public ICache Cache { get; set; }

        [Dependency]
        public ITelemetry Telemetry { get; set; }
        
        [Dependency]
        public ICurrencyService CurrencyService { get; set; }

        [Dependency]
        public ICustomerService CustomerService { get; set; }

        [Dependency]
        public IEmployeeService EmployeeService { get; set; }

        [Dependency]
        public IJobService JobService { get; set; }

        [Dependency]
        public IOrderService OrderService { get; set; }

        [Dependency]
        public IOrganizationBranchService OrganizationBranchService { get; set; }

        [Dependency]
        public IOrganizationDepartmentService OrganizationDepartmentService { get; set; }

        [Dependency]
        public IOrganizationService OrganizationService { get; set; }

        [Dependency]
        public IProductService ProductService { get; set; }

        [Dependency]
        public IServiceService ServiceService { get; set; }

        [Dependency]
        public ISupplierService SupplierService { get; set; }

        [Dependency]
        public ITaskService TaskService { get; set; }

        [Dependency]
        public IWorkflowService WorkflowService { get; set; }

        #region IDisposable implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ServiceProviderBusiness()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }


            if (disposing)
            {
                if (Container != null)
                {
                    Container.Dispose();
                    Container = null;
                }
            }

            // release any unmanaged objects
            // set the object references to null

            disposed = true;
        }

        #endregion
    }
}
