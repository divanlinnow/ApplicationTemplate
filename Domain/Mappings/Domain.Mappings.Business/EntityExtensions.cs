using System.Collections.Generic;
using System.Linq;
using Domain.Models.Business;
using Domain.Entities.Business;
using Domain.Mappings.Core;

namespace Domain.Mappings.Business
{
    /*
     * Here we are manually mapping out our objects instead of using a tool such as "AutoMapper". 
     * This is done to avoid mistakes such as silent mapping failures that get hidden from the developer and to see mapping failures clearly break during build compilation.
     * If we use a mapping tool, then we would also need to write additional unit tests to prove that our mapping tool works correctly.
     */

    public static class EntityExtensions
    {
        public static CurrencyDto AsDto(this Currency currency)
        {
            if (currency == null)
            {
                return null;
            }

            return new CurrencyDto
            {
                Id = currency.ID,
                ISOCode = currency.ISOCode,
                Abbreviation = currency.Abbreviation,
                Name = currency.Name
            };
        }

        public static IList<CurrencyDto> AsDto(this IList<Currency> currencies)
        {
            return currencies == null ? new List<CurrencyDto>() : currencies.Select(x => x.AsDto()).ToList();
        }

        public static CustomerDto AsDto(this Customer customer)
        {
            if (customer == null)
            {
                return null;
            }

            return new CustomerDto
            {
                Id = customer.ID,
                User = customer.User.AsDto(),
                Orders = customer.Orders.AsDto(),
                CreditBlocked = customer.CreditBlocked,
                CreditLimit = customer.CreditLimit,
                AllowancePeriod_Days = customer.AllowancePeriod_Days,
                AllowancePeriod_Months = customer.AllowancePeriod_Months,
                IsPreferredCustomer = customer.IsPreferredCustomer
            };
        }

        public static IList<CustomerDto> AsDto(this IList<Customer> customers)
        {
            return customers == null ? new List<CustomerDto>() : customers.Select(x => x.AsDto()).ToList();
        }

        public static EmployeeDto AsDto(this Employee employee)
        {
            if (employee == null)
            {
                return null;
            }

            return new EmployeeDto
            {
                Id = employee.ID,
                User = employee.User.AsDto(),
                Organization = employee.Organization.AsDto(),
                Branch = employee.Branch.AsDto(),
                Department = employee.Department.AsDto(),
                Job = employee.Job.AsDto()
            };
        }

        public static IList<EmployeeDto> AsDto(this IList<Employee> employees)
        {
            return employees == null ? new List<EmployeeDto>() : employees.Select(x => x.AsDto()).ToList();
        }

        public static JobDto AsDto(this Job job)
        {
            if (job == null)
            {
                return null;
            }

            return new JobDto
            {
                Id = job.ID,
                Organization = job.Organization.AsDto(),
                Branch = job.Branch.AsDto(),
                Department = job.Department.AsDto(),
                Title = job.Title,
                Role = job.Role.AsDto(),
                Created = job.Created,
                CreatedBy = job.CreatedBy.AsDto(),
                Modified = job.Modified,
                ModifiedBy = job.ModifiedBy.AsDto(),
                IsActive = job.IsActive,
                IsDeleted = job.IsDeleted
            };
        }

        public static IList<JobDto> AsDto(this IList<Job> jobs)
        {
            return jobs == null ? new List<JobDto>() : jobs.Select(x => x.AsDto()).ToList();
        }

        public static OrderDto AsDto(this Order order)
        {
            if (order == null)
            {
                return null;
            }

            return new OrderDto
            {
                Id = order.ID,
                Customer = order.Customer.AsDto(),
                PlacementDate = order.PlacementDate,
                Products = order.Products.AsDto(),
                Services = order.Services.AsDto(),
                TrackingNumber = order.TrackingNumber,
                DeliveryAddress = order.DeliveryAddress.AsDto(),
                CollectionAddress = order.CollectionAddress.AsDto(),
                Created = order.Created,
                CreatedBy = order.CreatedBy.AsDto(),
                Modified = order.Modified,
                ModifiedBy = order.ModifiedBy.AsDto(),
                IsForCollection = order.IsForCollection,
                IsForDelivery = order.IsForDelivery,
                IsQuote = order.IsQuote,
                IsCancelled = order.IsCancelled,
                IsActive = order.IsActive,
                IsDeleted = order.IsDeleted
            };
        }

        public static IList<OrderDto> AsDto(this IList<Order> orders)
        {
            return orders == null ? new List<OrderDto>() : orders.Select(x => x.AsDto()).ToList();
        }

        public static OrganizationBranchDto AsDto(this OrganizationBranch organizationBranch)
        {
            if (organizationBranch == null)
            {
                return null;
            }

            return new OrganizationBranchDto
            {
                Id = organizationBranch.ID,
                Name = organizationBranch.Name,
                Organization = organizationBranch.Organization.AsDto(),
                Departments = organizationBranch.Departments.AsDto(),
                Address = organizationBranch.Address.AsDto(),
                Created = organizationBranch.Created,
                CreatedBy = organizationBranch.CreatedBy.AsDto(),
                Modified = organizationBranch.Modified,
                ModifiedBy = organizationBranch.ModifiedBy.AsDto(),
                IsDeleted = organizationBranch.IsDeleted
            };
        }

        public static IList<OrganizationBranchDto> AsDto(this IList<OrganizationBranch> organizationBranches)
        {
            return organizationBranches == null ? new List<OrganizationBranchDto>() : organizationBranches.Select(x => x.AsDto()).ToList();
        }

        public static OrganizationDepartmentDto AsDto(this OrganizationDepartment organizationDepartment)
        {
            if (organizationDepartment == null)
            {
                return null;
            }

            return new OrganizationDepartmentDto
            {
                Id = organizationDepartment.ID,
                Name = organizationDepartment.Name,
                Organization = organizationDepartment.Organization.AsDto(),
                Branch = organizationDepartment.Branch.AsDto(),
                Employees = organizationDepartment.Employees.AsDto(),
                Address = organizationDepartment.Address.AsDto(),
                Created = organizationDepartment.Created,
                CreatedBy = organizationDepartment.CreatedBy.AsDto(),
                Modified = organizationDepartment.Modified,
                ModifiedBy = organizationDepartment.ModifiedBy.AsDto(),
                IsActive = organizationDepartment.IsActive,
                IsDeleted = organizationDepartment.IsDeleted
            };
        }

        public static IList<OrganizationDepartmentDto> AsDto(this IList<OrganizationDepartment> organizationDepartments)
        {
            return organizationDepartments == null ? new List<OrganizationDepartmentDto>() : organizationDepartments.Select(x => x.AsDto()).ToList();
        }

        public static OrganizationDto AsDto(this Organization organization)
        {
            if (organization == null)
            {
                return null;
            }

            return new OrganizationDto
            {
                Id = organization.ID,
                RegisteredName = organization.RegisteredName,
                PrintName = organization.PrintName,
                Branches = organization.Branches.AsDto(),
                Created = organization.Created,
                CreatedBy = organization.CreatedBy.AsDto(),
                Modified = organization.Modified,
                ModifiedBy = organization.ModifiedBy.AsDto(),
                IsRegistered = organization.IsRegistered,
                IsActive = organization.IsActive,
                IsDeleted = organization.IsDeleted
            };
        }

        public static IList<OrganizationDto> AsDto(this IList<Organization> organizations)
        {
            return organizations == null ? new List<OrganizationDto>() : organizations.Select(x => x.AsDto()).ToList();
        }

        public static ProductDto AsDto(this Product product)
        {
            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                Id = product.ID,
                Name = product.Name,
                Make = product.Make,
                Model = product.Model,
                Year = product.Year,
                Description = product.Description,
                MinimumOrderQuantity = product.MinimumOrderQuantity,
                PriceEXCL = product.PriceEXCL,
                PriceINCL = product.PriceINCL,
                PriceMustChange = product.PriceMustChange,
                PriceExpiryDate = product.PriceExpiryDate,
                HasExpiryDate = product.HasExpiryDate,
                ExpiryDate = product.ExpiryDate,
                Supplier = product.Supplier.AsDto(),
                Created = product.Created,
                CreatedBy = product.CreatedBy.AsDto(),
                Modified = product.Modified,
                ModifiedBy = product.ModifiedBy.AsDto(),
                IsActive = product.IsActive,
                IsDeleted = product.IsDeleted
            };
        }

        public static IList<ProductDto> AsDto(this IList<Product> products)
        {
            return products == null ? new List<ProductDto>() : products.Select(x => x.AsDto()).ToList();
        }

        public static ProductOrderItemDto AsDto(this ProductOrderItem productOrderItem)
        {
            if (productOrderItem == null)
            {
                return null;
            }

            return new ProductOrderItemDto
            {
                OrderId = productOrderItem.OrderId,
                ProductId = productOrderItem.ProductId,
                Quantity = productOrderItem.Quantity
            };
        }

        public static IList<ProductOrderItemDto> AsDto(this IList<ProductOrderItem> productOrderItems)
        {
            return productOrderItems == null ? new List<ProductOrderItemDto>() : productOrderItems.Select(x => x.AsDto()).ToList();
        }

        public static ServiceDto AsDto(this Service service)
        {
            if (service == null)
            {
                return null;
            }

            return new ServiceDto
            {
                Id = service.ID,
                Name = service.Name,
                Description = service.Description,
                MinimumOrderQuantity = service.MinimumOrderQuantity,
                PriceEXCL = service.PriceEXCL,
                PriceINCL = service.PriceINCL,
                PriceMustChange = service.PriceMustChange,
                PriceExpiryDate = service.PriceExpiryDate,
                HasExpiryDate = service.HasExpiryDate,
                ExpiryDate = service.ExpiryDate,
                Supplier = service.Supplier.AsDto(),
                Created = service.Created,
                CreatedBy = service.CreatedBy.AsDto(),
                Modified = service.Modified,
                ModifiedBy = service.ModifiedBy.AsDto(),
                IsActive = service.IsActive,
                IsDeleted = service.IsDeleted
            };
        }

        public static IList<ServiceDto> AsDto(this IList<Service> services)
        {
            return services == null ? new List<ServiceDto>() : services.Select(x => x.AsDto()).ToList();
        }

        public static ServiceOrderItemDto AsDto(this ServiceOrderItem serviceOrderItem)
        {
            if (serviceOrderItem == null)
            {
                return null;
            }

            return new ServiceOrderItemDto
            {
                OrderId = serviceOrderItem.OrderId,
                ServiceId = serviceOrderItem.ServiceId,
                Quantity = serviceOrderItem.Quantity
            };
        }

        public static IList<ServiceOrderItemDto> AsDto(this IList<ServiceOrderItem> serviceOrderItems)
        {
            return serviceOrderItems == null ? new List<ServiceOrderItemDto>() : serviceOrderItems.Select(x => x.AsDto()).ToList();
        }

        public static SupplierDto AsDto(this Supplier supplier)
        {
            if (supplier == null)
            {
                return null;
            }

            return new SupplierDto
            {
                Id = supplier.ID,
                Organization = supplier.Organization.AsDto(),
                Name = supplier.Name,
                Created = supplier.Created,
                CreatedBy = supplier.CreatedBy.AsDto(),
                Modified = supplier.Modified,
                ModifiedBy = supplier.ModifiedBy.AsDto(),
                IsActive = supplier.IsActive,
                IsDeleted = supplier.IsDeleted
            };
        }

        public static IList<SupplierDto> AsDto(this IList<Supplier> suppliers)
        {
            return suppliers == null ? new List<SupplierDto>() : suppliers.Select(x => x.AsDto()).ToList();
        }

        public static TaskDto AsDto(this Task task)
        {
            if (task == null)
            {
                return null;
            }

            return new TaskDto
            {
                Id = task.ID,
                Name = task.Name,
                Description = task.Description,
                AssignedTo = task.AssignedTo.AsDto(),
                AssignedBy = task.AssignedBy.AsDto(),
                EstimatedStart = task.EstimatedStart,
                EstimatedEnd = task.EstimatedEnd,
                ActualStart = task.ActualStart,
                ActualEnd = task.ActualEnd,
                Status = task.Status.AsDto(),
                Created = task.Created,
                CreatedBy = task.CreatedBy.AsDto(),
                Modified = task.Modified,
                ModifiedBy = task.ModifiedBy.AsDto(),
                IsActive = task.IsActive,
                IsDeleted = task.IsDeleted
            };
        }

        public static IList<TaskDto> AsDto(this IList<Task> tasks)
        {
            return tasks == null ? new List<TaskDto>() : tasks.Select(x => x.AsDto()).ToList();
        }

        public static TaskStatusDto AsDto(this TaskStatus taskStatus)
        {
            if (taskStatus == null)
            {
                return null;
            }

            return new TaskStatusDto
            {
                Id = taskStatus.ID,
                Name = taskStatus.Name,
                Created = taskStatus.Created,
                CreatedBy = taskStatus.CreatedBy.AsDto(),
                Modified = taskStatus.Modified,
                ModifiedBy = taskStatus.ModifiedBy.AsDto(),
                IsActive = taskStatus.IsActive,
                IsDeleted = taskStatus.IsDeleted
            };
        }

        public static IList<TaskStatusDto> AsDto(this IList<TaskStatus> taskStatuses)
        {
            return taskStatuses == null ? new List<TaskStatusDto>() : taskStatuses.Select(x => x.AsDto()).ToList();
        }

        public static WorkflowDto AsDto(this Workflow workflow)
        {
            if (workflow == null)
            {
                return null;
            }

            return new WorkflowDto
            {
                Id = workflow.ID,
                Name = workflow.Name,
                Description = workflow.Description,
                Department = workflow.Department.AsDto(),
                Employees = workflow.Employees.AsDto(),
                Tasks = workflow.Tasks.AsDto(),
                Created = workflow.Created,
                CreatedBy = workflow.CreatedBy.AsDto(),
                Modified = workflow.Modified,
                ModifiedBy = workflow.ModifiedBy.AsDto(),
                IsActive = workflow.IsActive,
                IsDeleted = workflow.IsDeleted
            };
        }

        public static IList<WorkflowDto> AsDto(this IList<Workflow> workflows)
        {
            return workflows == null ? new List<WorkflowDto>() : workflows.Select(x => x.AsDto()).ToList();
        }
    }
}