using System.Collections.Generic;
using System.Linq;
using Domain.Entities.Business;
using Domain.Mappings.Core;
using Domain.Models.Business;

namespace Domain.Mappings.Business
{
    /*
     * Here we are manually mapping out our objects instead of using a tool such as "AutoMapper". 
     * This is done to avoid mistakes such as silent mapping failures that get hidden from the developer and to see mapping failures clearly break during build compilation.
     * If we use a mapping tool, then we would also need to write additional unit tests to prove that our mapping tool works correctly.
     */

    public static class ModelExtensions
    {
        public static Currency AsEntity(this CurrencyDto currencyDto)
        {
            if (currencyDto == null)
            {
                return null;
            }

            return new Currency
            {
                ID = currencyDto.Id,
                ISOCode = currencyDto.ISOCode,
                Abbreviation = currencyDto.Abbreviation,
                Name = currencyDto.Name
            };
        }

        public static IList<Currency> AsEntity(this IList<CurrencyDto> currencies)
        {
            return currencies == null ? new List<Currency>() : currencies.Select(x => x.AsEntity()).ToList();
        }

        public static Customer AsEntity(this CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return null;
            }

            return new Customer
            {
                ID = customerDto.Id,
                User = customerDto.User.AsEntity(),
                Orders = customerDto.Orders.AsEntity(),
                CreditBlocked = customerDto.CreditBlocked,
                CreditLimit = customerDto.CreditLimit,
                AllowancePeriod_Days = customerDto.AllowancePeriod_Days,
                AllowancePeriod_Months = customerDto.AllowancePeriod_Months,
                IsPreferredCustomer = customerDto.IsPreferredCustomer
            };
        }

        public static IList<Customer> AsEntity(this IList<CustomerDto> customers)
        {
            return customers == null ? new List<Customer>() : customers.Select(x => x.AsEntity()).ToList();
        }

        public static Employee AsEntity(this EmployeeDto employeeDto)
        {
            if (employeeDto == null)
            {
                return null;
            }

            return new Employee
            {
                ID = employeeDto.Id,
                User = employeeDto.User.AsEntity(),
                Organization = employeeDto.Organization.AsEntity(),
                Branch = employeeDto.Branch.AsEntity(),
                Department = employeeDto.Department.AsEntity(),
                Job = employeeDto.Job.AsEntity()
            };
        }

        public static IList<Employee> AsEntity(this IList<EmployeeDto> employees)
        {
            return employees == null ? new List<Employee>() : employees.Select(x => x.AsEntity()).ToList();
        }

        public static Job AsEntity(this JobDto jobDto)
        {
            if (jobDto == null)
            {
                return null;
            }

            return new Job
            {
                ID = jobDto.Id,
                Organization = jobDto.Organization.AsEntity(),
                Branch = jobDto.Branch.AsEntity(),
                Department = jobDto.Department.AsEntity(),
                Title = jobDto.Title,
                Role = jobDto.Role.AsEntity(),
                Created = jobDto.Created,
                CreatedBy = jobDto.CreatedBy.AsEntity(),
                Modified = jobDto.Modified,
                ModifiedBy = jobDto.ModifiedBy.AsEntity(),
                IsActive = jobDto.IsActive,
                IsDeleted = jobDto.IsDeleted
            };
        }

        public static IList<Job> AsEntity(this IList<JobDto> jobs)
        {
            return jobs == null ? new List<Job>() : jobs.Select(x => x.AsEntity()).ToList();
        }

        public static Order AsEntity(this OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return null;
            }

            return new Order
            {
                ID = orderDto.Id,
                Customer = orderDto.Customer.AsEntity(),
                PlacementDate = orderDto.PlacementDate,
                Products = orderDto.Products.AsEntity(),
                Services = orderDto.Services.AsEntity(),
                TrackingNumber = orderDto.TrackingNumber,
                DeliveryAddress = orderDto.DeliveryAddress.AsEntity(),
                CollectionAddress = orderDto.CollectionAddress.AsEntity(),
                Created = orderDto.Created,
                CreatedBy = orderDto.CreatedBy.AsEntity(),
                Modified = orderDto.Modified,
                ModifiedBy = orderDto.ModifiedBy.AsEntity(),
                IsForCollection = orderDto.IsForCollection,
                IsForDelivery = orderDto.IsForDelivery,
                IsQuote = orderDto.IsQuote,
                IsCancelled = orderDto.IsCancelled,
                IsActive = orderDto.IsActive,
                IsDeleted = orderDto.IsDeleted
            };
        }

        public static IList<Order> AsEntity(this IList<OrderDto> orders)
        {
            return orders == null ? new List<Order>() : orders.Select(x => x.AsEntity()).ToList();
        }

        public static OrganizationBranch AsEntity(this OrganizationBranchDto organizationBranchDto)
        {
            if (organizationBranchDto == null)
            {
                return null;
            }

            return new OrganizationBranch
            {
                ID = organizationBranchDto.Id,
                Name = organizationBranchDto.Name,
                Organization = organizationBranchDto.Organization.AsEntity(),
                Departments = organizationBranchDto.Departments.AsEntity(),
                Address = organizationBranchDto.Address.AsEntity(),
                Created = organizationBranchDto.Created,
                CreatedBy = organizationBranchDto.CreatedBy.AsEntity(),
                Modified = organizationBranchDto.Modified,
                ModifiedBy = organizationBranchDto.ModifiedBy.AsEntity(),
                IsDeleted = organizationBranchDto.IsDeleted
            };
        }

        public static IList<OrganizationBranch> AsEntity(this IList<OrganizationBranchDto> organizationBranches)
        {
            return organizationBranches == null ? new List<OrganizationBranch>() : organizationBranches.Select(x => x.AsEntity()).ToList();
        }

        public static OrganizationDepartment AsEntity(this OrganizationDepartmentDto organizationDepartmentDto)
        {
            if (organizationDepartmentDto == null)
            {
                return null;
            }

            return new OrganizationDepartment
            {
                ID = organizationDepartmentDto.Id,
                Name = organizationDepartmentDto.Name,
                Organization = organizationDepartmentDto.Organization.AsEntity(),
                Branch = organizationDepartmentDto.Branch.AsEntity(),
                Employees = organizationDepartmentDto.Employees.AsEntity(),
                Address = organizationDepartmentDto.Address.AsEntity(),
                Created = organizationDepartmentDto.Created,
                CreatedBy = organizationDepartmentDto.CreatedBy.AsEntity(),
                Modified = organizationDepartmentDto.Modified,
                ModifiedBy = organizationDepartmentDto.ModifiedBy.AsEntity(),
                IsActive = organizationDepartmentDto.IsActive,
                IsDeleted = organizationDepartmentDto.IsDeleted
            };
        }

        public static IList<OrganizationDepartment> AsEntity(this IList<OrganizationDepartmentDto> organizationDepartments)
        {
            return organizationDepartments == null ? new List<OrganizationDepartment>() : organizationDepartments.Select(x => x.AsEntity()).ToList();
        }

        public static Organization AsEntity(this OrganizationDto organizationDto)
        {
            if (organizationDto == null)
            {
                return null;
            }

            return new Organization
            {
                ID = organizationDto.Id,
                RegisteredName = organizationDto.RegisteredName,
                PrintName = organizationDto.PrintName,
                Branches = organizationDto.Branches.AsEntity(),
                Created = organizationDto.Created,
                CreatedBy = organizationDto.CreatedBy.AsEntity(),
                Modified = organizationDto.Modified,
                ModifiedBy = organizationDto.ModifiedBy.AsEntity(),
                IsRegistered = organizationDto.IsRegistered,
                IsActive = organizationDto.IsActive,
                IsDeleted = organizationDto.IsDeleted
            };
        }

        public static IList<Organization> AsEntity(this IList<OrganizationDto> organizations)
        {
            return organizations == null ? new List<Organization>() : organizations.Select(x => x.AsEntity()).ToList();
        }

        public static Product AsEntity(this ProductDto productDto)
        {
            if (productDto == null)
            {
                return null;
            }

            return new Product
            {
                ID = productDto.Id,
                Name = productDto.Name,
                Make = productDto.Make,
                Model = productDto.Model,
                Year = productDto.Year,
                Description = productDto.Description,
                MinimumOrderQuantity = productDto.MinimumOrderQuantity,
                PriceEXCL = productDto.PriceEXCL,
                PriceINCL = productDto.PriceINCL,
                PriceMustChange = productDto.PriceMustChange,
                PriceExpiryDate = productDto.PriceExpiryDate,
                HasExpiryDate = productDto.HasExpiryDate,
                ExpiryDate = productDto.ExpiryDate,
                Supplier = productDto.Supplier.AsEntity(),
                Created = productDto.Created,
                CreatedBy = productDto.CreatedBy.AsEntity(),
                Modified = productDto.Modified,
                ModifiedBy = productDto.ModifiedBy.AsEntity(),
                IsActive = productDto.IsActive,
                IsDeleted = productDto.IsDeleted
            };
        }

        public static IList<Product> AsEntity(this IList<ProductDto> products)
        {
            return products == null ? new List<Product>() : products.Select(x => x.AsEntity()).ToList();
        }

        public static ProductOrderItem AsEntity(this ProductOrderItemDto productOrderItemDto)
        {
            if (productOrderItemDto == null)
            {
                return null;
            }

            return new ProductOrderItem
            {
                OrderId = productOrderItemDto.OrderId,
                ProductId = productOrderItemDto.ProductId,
                Quantity = productOrderItemDto.Quantity
            };
        }

        public static IList<ProductOrderItem> AsEntity(this IList<ProductOrderItemDto> productOrderItems)
        {
            return productOrderItems == null ? new List<ProductOrderItem>() : productOrderItems.Select(x => x.AsEntity()).ToList();
        }

        public static Service AsEntity(this ServiceDto serviceDto)
        {
            if (serviceDto == null)
            {
                return null;
            }

            return new Service
            {
                ID = serviceDto.Id,
                Name = serviceDto.Name,
                Description = serviceDto.Description,
                MinimumOrderQuantity = serviceDto.MinimumOrderQuantity,
                PriceEXCL = serviceDto.PriceEXCL,
                PriceINCL = serviceDto.PriceINCL,
                PriceMustChange = serviceDto.PriceMustChange,
                PriceExpiryDate = serviceDto.PriceExpiryDate,
                HasExpiryDate = serviceDto.HasExpiryDate,
                ExpiryDate = serviceDto.ExpiryDate,
                Supplier = serviceDto.Supplier.AsEntity(),
                Created = serviceDto.Created,
                CreatedBy = serviceDto.CreatedBy.AsEntity(),
                Modified = serviceDto.Modified,
                ModifiedBy = serviceDto.ModifiedBy.AsEntity(),
                IsActive = serviceDto.IsActive,
                IsDeleted = serviceDto.IsDeleted
            };
        }

        public static IList<Service> AsEntity(this IList<ServiceDto> services)
        {
            return services == null ? new List<Service>() : services.Select(x => x.AsEntity()).ToList();
        }

        public static ServiceOrderItem AsEntity(this ServiceOrderItemDto serviceOrderItemDto)
        {
            if (serviceOrderItemDto == null)
            {
                return null;
            }

            return new ServiceOrderItem
            {
                OrderId = serviceOrderItemDto.OrderId,
                ServiceId = serviceOrderItemDto.ServiceId,
                Quantity = serviceOrderItemDto.Quantity
            };
        }

        public static IList<ServiceOrderItem> AsEntity(this IList<ServiceOrderItemDto> serviceOrderItems)
        {
            return serviceOrderItems == null ? new List<ServiceOrderItem>() : serviceOrderItems.Select(x => x.AsEntity()).ToList();
        }

        public static Supplier AsEntity(this SupplierDto supplierDto)
        {
            if (supplierDto == null)
            {
                return null;
            }

            return new Supplier
            {
                ID = supplierDto.Id,
                Organization = supplierDto.Organization.AsEntity(),
                Name = supplierDto.Name,
                Created = supplierDto.Created,
                CreatedBy = supplierDto.CreatedBy.AsEntity(),
                Modified = supplierDto.Modified,
                ModifiedBy = supplierDto.ModifiedBy.AsEntity(),
                IsActive = supplierDto.IsActive,
                IsDeleted = supplierDto.IsDeleted
            };
        }

        public static IList<Supplier> AsEntity(this IList<SupplierDto> suppliers)
        {
            return suppliers == null ? new List<Supplier>() : suppliers.Select(x => x.AsEntity()).ToList();
        }

        public static Task AsEntity(this TaskDto taskDto)
        {
            if (taskDto == null)
            {
                return null;
            }

            return new Task
            {
                ID = taskDto.Id,
                Name = taskDto.Name,
                Description = taskDto.Description,
                AssignedTo = taskDto.AssignedTo.AsEntity(),
                AssignedBy = taskDto.AssignedBy.AsEntity(),
                EstimatedStart = taskDto.EstimatedStart,
                EstimatedEnd = taskDto.EstimatedEnd,
                ActualStart = taskDto.ActualStart,
                ActualEnd = taskDto.ActualEnd,
                Status = taskDto.Status.AsEntity(),
                Created = taskDto.Created,
                CreatedBy = taskDto.CreatedBy.AsEntity(),
                Modified = taskDto.Modified,
                ModifiedBy = taskDto.ModifiedBy.AsEntity(),
                IsActive = taskDto.IsActive,
                IsDeleted = taskDto.IsDeleted
            };
        }

        public static IList<Task> AsEntity(this IList<TaskDto> tasks)
        {
            return tasks == null ? new List<Task>() : tasks.Select(x => x.AsEntity()).ToList();
        }

        public static TaskStatus AsEntity(this TaskStatusDto taskStatusDto)
        {
            if (taskStatusDto == null)
            {
                return null;
            }

            return new TaskStatus
            {
                ID = taskStatusDto.Id,
                Name = taskStatusDto.Name,
                Created = taskStatusDto.Created,
                CreatedBy = taskStatusDto.CreatedBy.AsEntity(),
                Modified = taskStatusDto.Modified,
                ModifiedBy = taskStatusDto.ModifiedBy.AsEntity(),
                IsActive = taskStatusDto.IsActive,
                IsDeleted = taskStatusDto.IsDeleted
            };
        }

        public static IList<TaskStatus> AsEntity(this IList<TaskStatusDto> taskStatuses)
        {
            return taskStatuses == null ? new List<TaskStatus>() : taskStatuses.Select(x => x.AsEntity()).ToList();
        }

        public static Workflow AsEntity(this WorkflowDto workflowDto)
        {
            if (workflowDto == null)
            {
                return null;
            }

            return new Workflow
            {
                ID = workflowDto.Id,
                Name = workflowDto.Name,
                Description = workflowDto.Description,
                Department = workflowDto.Department.AsEntity(),
                Employees = workflowDto.Employees.AsEntity(),
                Tasks = workflowDto.Tasks.AsEntity(),
                Created = workflowDto.Created,
                CreatedBy = workflowDto.CreatedBy.AsEntity(),
                Modified = workflowDto.Modified,
                ModifiedBy = workflowDto.ModifiedBy.AsEntity(),
                IsActive = workflowDto.IsActive,
                IsDeleted = workflowDto.IsDeleted
            };
        }

        public static IList<Workflow> AsEntity(this IList<WorkflowDto> workflows)
        {
            return workflows == null ? new List<Workflow>() : workflows.Select(x => x.AsEntity()).ToList();
        }
    }
}
