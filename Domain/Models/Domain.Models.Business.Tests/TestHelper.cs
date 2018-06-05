using System;
using System.Collections.Generic;

namespace Domain.Models.Business.Tests
{
    public class TestHelper
    {
        public static CurrencyDto CurrencyDto()
        {
            return new CurrencyDto
            {
                ISOCode = "XXX",
                Abbreviation = "TC",
                Name = "Test Currency"
            };
        }

        public static List<CurrencyDto> CurrencyDtos()
        {
            return new List<CurrencyDto>
            {
                new CurrencyDto
                {
                    ISOCode = "XXX",
                    Abbreviation = "TC",
                    Name = "Test Currency 1"
                },
                new CurrencyDto
                {
                    ISOCode = "XXX",
                    Abbreviation = "TC",
                    Name = "Test Currency 2"
                }
            };
        }

        public static CustomerDto CustomerDto()
        {
            return new CustomerDto
            {
                User = Core.Tests.TestHelper.UserDto(),
                CreditBlocked = false,
                CreditLimit = 100,
                AllowancePeriod_Days = 10,
                AllowancePeriod_Months = 10,
                IsPreferredCustomer = true
            };
        }

        public static EmployeeDto EmployeeDto()
        {
            return new EmployeeDto
            {
                User = Core.Tests.TestHelper.UserDto(),
                Organization = OrganizationDto(),
                Branch = OrganizationBranchDto(),
                Department = OrganizationDepartmentDto(),
                Job = JobDto()
            };
        }

        public static List<EmployeeDto> EmployeeDtos()
        {
            return new List<EmployeeDto>
            {
                new EmployeeDto
                {
                    User = Core.Tests.TestHelper.UserDto(),
                    Organization = OrganizationDto(),
                    Branch = OrganizationBranchDto(),
                    Department = OrganizationDepartmentDto(),
                    Job = JobDto()
                },
                new EmployeeDto
                {
                    User = Core.Tests.TestHelper.UserDto(),
                    Organization = OrganizationDto(),
                    Branch = OrganizationBranchDto(),
                    Department = OrganizationDepartmentDto(),
                    Job = JobDto()
                }
            };
        }

        public static OrganizationDto OrganizationDto()
        {
            return new OrganizationDto
            {
                RegisteredName = "Test Registered Organization Name",
                PrintName = "Test Organization",
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.UserDto(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static OrganizationBranchDto OrganizationBranchDto()
        {
            return new OrganizationBranchDto
            {
                Name = "Test Branch",
                Organization = OrganizationDto(),
                Address = Core.Tests.TestHelper.AddressDto(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.UserDto(),
                IsDeleted = false
            };
        }

        public static List<OrganizationBranchDto> OrganizationBranchDtos()
        {
            return new List<OrganizationBranchDto>
            {
                new OrganizationBranchDto
                {
                    Name = "Test Branch 1",
                    Organization = OrganizationDto(),
                    Address = Core.Tests.TestHelper.AddressDto(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.UserDto(),
                    IsDeleted = false
                },
                new OrganizationBranchDto
                {
                    Name = "Test Branch 2",
                    Organization = OrganizationDto(),
                    Address = Core.Tests.TestHelper.AddressDto(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.UserDto(),
                    IsDeleted = false
                }
            };
        }

        public static OrganizationDepartmentDto OrganizationDepartmentDto()
        {
            return new OrganizationDepartmentDto
            {
                Name = "Test Department",
                Organization = OrganizationDto(),
                Branch = OrganizationBranchDto(),
                Address = Core.Tests.TestHelper.AddressDto(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.UserDto(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<OrganizationDepartmentDto> OrganizationDepartments()
        {
            return new List<OrganizationDepartmentDto>
            {
                new OrganizationDepartmentDto
                {
                    Name = "Test Department 1",
                    Organization = OrganizationDto(),
                    Branch = OrganizationBranchDto(),
                    Address = Core.Tests.TestHelper.AddressDto(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.UserDto(),
                    IsActive = true,
                    IsDeleted = false
                },
                new OrganizationDepartmentDto
                {
                    Name = "Test Department 2",
                    Organization = OrganizationDto(),
                    Branch = OrganizationBranchDto(),
                    Address = Core.Tests.TestHelper.AddressDto(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.UserDto(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static JobDto JobDto()
        {
            return new JobDto
            {
                Organization = OrganizationDto(),
                Branch = OrganizationBranchDto(),
                Department = OrganizationDepartmentDto(),
                Title = "Test Job",
                Role = Core.Tests.TestHelper.RoleDto(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.UserDto(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static OrderDto OrderDto()
        {
            return new OrderDto
            {
                Customer = CustomerDto(),
                PlacementDate = DateTime.Now,
                Products = ProductOrderItemDtos(),
                Services = ServiceOrderItems(),
                TrackingNumber = "Test Tracking Number ABC 123",
                DeliveryAddress = Core.Tests.TestHelper.AddressDto(),
                CollectionAddress = Core.Tests.TestHelper.AddressDto(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.UserDto(),
                IsForCollection = false,
                IsForDelivery = true,
                IsQuote = false,
                IsCancelled = false,
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<OrderDto> Orders()
        {
            return new List<OrderDto>
            {
                new OrderDto
                {
                    Customer = CustomerDto(),
                    PlacementDate = DateTime.Now,
                    Products = ProductOrderItemDtos(),
                    Services = ServiceOrderItems(),
                    TrackingNumber = "Test Tracking Number ABC 123",
                    DeliveryAddress = Core.Tests.TestHelper.AddressDto(),
                    CollectionAddress = Core.Tests.TestHelper.AddressDto(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.UserDto(),
                    IsForCollection = false,
                    IsForDelivery = true,
                    IsQuote = false,
                    IsCancelled = false,
                    IsActive = true,
                    IsDeleted = false
                },
                new OrderDto
                {
                    Customer = CustomerDto(),
                    PlacementDate = DateTime.Now,
                    Products = ProductOrderItemDtos(),
                    Services = ServiceOrderItems(),
                    TrackingNumber = "Test Tracking Number ABC 123",
                    DeliveryAddress = Core.Tests.TestHelper.AddressDto(),
                    CollectionAddress = Core.Tests.TestHelper.AddressDto(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.UserDto(),
                    IsForCollection = false,
                    IsForDelivery = true,
                    IsQuote = false,
                    IsCancelled = false,
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static ProductDto ProductDto()
        {
            return new ProductDto
            {
                Name = "Test Product",
                Make = "Test Make",
                Model = "Test Model",
                Year = DateTime.Now.Year,
                Description = "Test Product Description",
                MinimumOrderQuantity = 10,
                PriceEXCL = 100,
                PriceINCL = 200,
                PriceMustChange = false,
                PriceExpiryDate = DateTime.Now.AddYears(1),
                HasExpiryDate = false,
                ExpiryDate = DateTime.Now.AddYears(10),
                Supplier = SupplierDto(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.UserDto(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static ProductOrderItemDto ProductOrderItemDto()
        {
            return new ProductOrderItemDto
            {
                OrderId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity = 10
            };
        }

        public static List<ProductOrderItemDto> ProductOrderItemDtos()
        {
            return new List<ProductOrderItemDto>
            {
                new ProductOrderItemDto
                {
                    OrderId = Guid.NewGuid(),
                    ProductId = Guid.NewGuid(),
                    Quantity = 10
                },
                new ProductOrderItemDto
                {
                    OrderId = Guid.NewGuid(),
                    ProductId = Guid.NewGuid(),
                    Quantity = 10
                }
            };
        }

        public static ServiceDto ServiceDto()
        {
            return new ServiceDto
            {
                Name = "Test Service",
                Description = "Test Service Description",
                MinimumOrderQuantity = 10,
                PriceEXCL = 100,
                PriceINCL = 200,
                PriceMustChange = false,
                PriceExpiryDate = DateTime.Now.AddYears(1),
                HasExpiryDate = false,
                ExpiryDate = DateTime.Now.AddYears(10),
                Supplier = SupplierDto(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.UserDto(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static ServiceOrderItemDto ServiceOrderItemDto()
        {
            return new ServiceOrderItemDto
            {
                OrderId = Guid.NewGuid(),
                ServiceId = Guid.NewGuid(),
                Quantity = 10
            };
        }

        public static List<ServiceOrderItemDto> ServiceOrderItems()
        {
            return new List<ServiceOrderItemDto>
            {
                new ServiceOrderItemDto
                {
                    OrderId = Guid.NewGuid(),
                    ServiceId = Guid.NewGuid(),
                    Quantity = 10
                },
                new ServiceOrderItemDto
                {
                    OrderId = Guid.NewGuid(),
                    ServiceId = Guid.NewGuid(),
                    Quantity = 10
                }
            };
        }

        public static SupplierDto SupplierDto()
        {
            return new SupplierDto
            {
                Organization = OrganizationDto(),
                Name = "Test Supplier",
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.UserDto(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static TaskStatusDto TaskStatusDto()
        {
            return new TaskStatusDto
            {
                Name = "Test Task Status",
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.UserDto(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static TaskDto TaskDto()
        {
            return new TaskDto
            {
                Name = "Test Task",
                Description = "Test Task Description",
                AssignedTo = EmployeeDto(),
                AssignedBy = EmployeeDto(),
                EstimatedStart = DateTime.Now,
                EstimatedEnd = DateTime.Now.AddDays(10),
                ActualStart = DateTime.Now,
                ActualEnd = DateTime.Now.AddDays(5),
                Status = TaskStatusDto(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.UserDto(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<TaskDto> TaskDtos()
        {
            return new List<TaskDto>
            {
                new TaskDto
                {
                    Name = "Test Task",
                    Description = "Test Task Description",
                    AssignedTo = EmployeeDto(),
                    AssignedBy = EmployeeDto(),
                    EstimatedStart = DateTime.Now,
                    EstimatedEnd = DateTime.Now.AddDays(10),
                    ActualStart = DateTime.Now,
                    ActualEnd = DateTime.Now.AddDays(5),
                    Status = TaskStatusDto(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.UserDto(),
                    IsActive = true,
                    IsDeleted = false
                },
                new TaskDto
                {
                    Name = "Test Task",
                    Description = "Test Task Description",
                    AssignedTo = EmployeeDto(),
                    AssignedBy = EmployeeDto(),
                    EstimatedStart = DateTime.Now,
                    EstimatedEnd = DateTime.Now.AddDays(10),
                    ActualStart = DateTime.Now,
                    ActualEnd = DateTime.Now.AddDays(5),
                    Status = TaskStatusDto(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.UserDto(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.UserDto(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static WorkflowDto WorkflowDto()
        {
            return new WorkflowDto
            {
                Name = "Test Workflow Process",
                Description = "Test Workflow Process Description",
                Department = OrganizationDepartmentDto(),
                Employees = EmployeeDtos(),
                Tasks = TaskDtos(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.UserDto(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.UserDto(),
                IsActive = true,
                IsDeleted = false
            };
        }
    }
}