using System;
using System.Collections.Generic;

namespace Domain.Entities.Business.Tests
{
    public class TestHelper
    {
        public static Currency Currency()
        {
            return new Currency
            {
                ISOCode = "XXX",
                Abbreviation = "TC",
                Name = "Test Currency"
            };
        }

        public static List<Currency> Currencies()
        {
            return new List<Currency>
            {
                new Currency
                {
                    ISOCode = "XXX",
                    Abbreviation = "TC",
                    Name = "Test Currency"
                },
                new Currency
                {
                    ISOCode = "XXX",
                    Abbreviation = "TC",
                    Name = "Test Currency"
                }
            };
        }

        public static Customer Customer()
        {
            return new Customer
            {
                User = Core.Tests.TestHelper.User(),
                CreditBlocked = false,
                CreditLimit = 100,
                AllowancePeriod_Days = 10,
                AllowancePeriod_Months = 10,
                IsPreferredCustomer = true
            };
        }

        public static List<Customer> Customers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    User = Core.Tests.TestHelper.User(),
                    CreditBlocked = false,
                    CreditLimit = 100,
                    AllowancePeriod_Days = 10,
                    AllowancePeriod_Months = 10,
                    IsPreferredCustomer = true
                },
                new Customer
                {
                    User = Core.Tests.TestHelper.User(),
                    CreditBlocked = false,
                    CreditLimit = 100,
                    AllowancePeriod_Days = 10,
                    AllowancePeriod_Months = 10,
                    IsPreferredCustomer = true
                }
            };
        }

        public static Employee Employee()
        {
            return new Employee
            {
                User = Core.Tests.TestHelper.User(),
                Organization = Organization(),
                Branch = OrganizationBranch(),
                Department = OrganizationDepartment(),
                Job = Job()
            };
        }

        public static List<Employee> Employees()
        {
            return new List<Employee>
            {
                new Employee
                {
                    User = Core.Tests.TestHelper.User(),
                    Organization = Organization(),
                    Branch = OrganizationBranch(),
                    Department = OrganizationDepartment(),
                    Job = Job()
                },
                new Employee
                {
                    User = Core.Tests.TestHelper.User(),
                    Organization = Organization(),
                    Branch = OrganizationBranch(),
                    Department = OrganizationDepartment(),
                    Job = Job()
                }
            };
        }

        public static Organization Organization()
        {
            return new Organization
            {
                RegisteredName = "Test Registered Organization Name",
                PrintName = "Test Organization",
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.User(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.User(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<Organization> Organizations()
        {
            return new List<Organization>
            {
                new Organization
                {
                    RegisteredName = "Test Registered Organization Name",
                    PrintName = "Test Organization 1",
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                },
                new Organization
                {
                    RegisteredName = "Test Registered Organization Name",
                    PrintName = "Test Organization 2",
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static OrganizationBranch OrganizationBranch()
        {
            return new OrganizationBranch
            {
                Name = "Test Branch",
                Organization = Organization(),
                Address = Core.Tests.TestHelper.Address(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.User(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.User(),
                IsDeleted = false
            };
        }

        public static List<OrganizationBranch> OrganizationBranches()
        {
            return new List<OrganizationBranch>
            {
                new OrganizationBranch
                {
                    Name = "Test Branch 1",
                    Organization = Organization(),
                    Address = Core.Tests.TestHelper.Address(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsDeleted = false
                },
                new OrganizationBranch
                {
                    Name = "Test Branch 2",
                    Organization = Organization(),
                    Address = Core.Tests.TestHelper.Address(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsDeleted = false
                }
            };
        }

        public static OrganizationDepartment OrganizationDepartment()
        {
            return new OrganizationDepartment
            {
                Name = "Test Department",
                Organization = Organization(),
                Branch = OrganizationBranch(),
                Address = Core.Tests.TestHelper.Address(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.User(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.User(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<OrganizationDepartment> OrganizationDepartments()
        {
            return new List<OrganizationDepartment>
            {
                new OrganizationDepartment
                {
                    Name = "Test Department 1",
                    Organization = Organization(),
                    Branch = OrganizationBranch(),
                    Address = Core.Tests.TestHelper.Address(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                },
                new OrganizationDepartment
                {
                    Name = "Test Department 2",
                    Organization = Organization(),
                    Branch = OrganizationBranch(),
                    Address = Core.Tests.TestHelper.Address(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static Job Job()
        {
            return new Job
            {
                Organization = Organization(),
                Branch = OrganizationBranch(),
                Department = OrganizationDepartment(),
                Title = "Test Job",
                Role = Core.Tests.TestHelper.Role(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.User(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.User(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<Job> Jobs()
        {
            return new List<Job>
            {
                new Job
                {
                    Organization = Organization(),
                    Branch = OrganizationBranch(),
                    Department = OrganizationDepartment(),
                    Title = "Test Job",
                    Role = Core.Tests.TestHelper.Role(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                },
                new Job
                {
                    Organization = Organization(),
                    Branch = OrganizationBranch(),
                    Department = OrganizationDepartment(),
                    Title = "Test Job",
                    Role = Core.Tests.TestHelper.Role(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static Order Order()
        {
            return new Order
            {
                Customer = Customer(),
                PlacementDate = DateTime.Now,
                Products = ProductOrderItems(),
                Services = ServiceOrderItems(),
                TrackingNumber = "Test Tracking Number ABC 123",
                DeliveryAddress = Core.Tests.TestHelper.Address(),
                CollectionAddress = Core.Tests.TestHelper.Address(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.User(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.User(),
                IsForCollection = false,
                IsForDelivery = true,
                IsQuote = false,
                IsCancelled = false,
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<Order> Orders()
        {
            return new List<Order>
            {
                new Order
                {
                    Customer = Customer(),
                    PlacementDate = DateTime.Now,
                    Products = ProductOrderItems(),
                    Services = ServiceOrderItems(),
                    TrackingNumber = "Test Tracking Number ABC 123",
                    DeliveryAddress = Core.Tests.TestHelper.Address(),
                    CollectionAddress = Core.Tests.TestHelper.Address(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsForCollection = false,
                    IsForDelivery = true,
                    IsQuote = false,
                    IsCancelled = false,
                    IsActive = true,
                    IsDeleted = false
                },
                new Order
                {
                    Customer = Customer(),
                    PlacementDate = DateTime.Now,
                    Products = ProductOrderItems(),
                    Services = ServiceOrderItems(),
                    TrackingNumber = "Test Tracking Number ABC 123",
                    DeliveryAddress = Core.Tests.TestHelper.Address(),
                    CollectionAddress = Core.Tests.TestHelper.Address(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsForCollection = false,
                    IsForDelivery = true,
                    IsQuote = false,
                    IsCancelled = false,
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static Product Product()
        {
            return new Product
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
                Supplier = Supplier(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.User(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.User(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<Product> Products()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Test Product 1",
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
                    Supplier = Supplier(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                },
                new Product
                {
                    Name = "Test Product 2",
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
                    Supplier = Supplier(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static ProductOrderItem ProductOrderItem()
        {
            return new ProductOrderItem
            {
                OrderId = 99,
                ProductId = 99,
                Quantity = 100
            };
        }

        public static List<ProductOrderItem> ProductOrderItems()
        {
            return new List<ProductOrderItem>
            {
                new ProductOrderItem
                {
                    OrderId = 99,
                    ProductId = 99,
                    Quantity = 100
                },
                new ProductOrderItem
                {
                    OrderId = 99,
                    ProductId = 99,
                    Quantity = 100
                }
            };
        }

        public static Service Service()
        {
            return new Service
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
                Supplier = Supplier(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.User(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.User(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<Service> Services()
        {
            return new List<Service>
            {
                new Service
                {
                    Name = "Test Service 1",
                    Description = "Test Service Description",
                    MinimumOrderQuantity = 10,
                    PriceEXCL = 100,
                    PriceINCL = 200,
                    PriceMustChange = false,
                    PriceExpiryDate = DateTime.Now.AddYears(1),
                    HasExpiryDate = false,
                    ExpiryDate = DateTime.Now.AddYears(10),
                    Supplier = Supplier(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                },
                new Service
                {
                    Name = "Test Service 2",
                    Description = "Test Service Description",
                    MinimumOrderQuantity = 10,
                    PriceEXCL = 100,
                    PriceINCL = 200,
                    PriceMustChange = false,
                    PriceExpiryDate = DateTime.Now.AddYears(1),
                    HasExpiryDate = false,
                    ExpiryDate = DateTime.Now.AddYears(10),
                    Supplier = Supplier(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static ServiceOrderItem ServiceOrderItem()
        {
            return new ServiceOrderItem
            {
                OrderId = 99,
                ServiceId = 99,
                Quantity = 100
            };
        }

        public static List<ServiceOrderItem> ServiceOrderItems()
        {
            return new List<ServiceOrderItem>
            {
                new ServiceOrderItem
                {
                    OrderId = 99,
                    ServiceId = 99,
                    Quantity = 100
                },
                new ServiceOrderItem
                {
                    OrderId = 99,
                    ServiceId = 99,
                    Quantity = 100
                }
            };
        }

        public static Supplier Supplier()
        {
            return new Supplier
            {
                Organization = Organization(),
                Name = "Test Supplier",
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.User(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.User(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<Supplier> Suppliers()
        {
            return new List<Supplier>
            {
                new Supplier
                {
                    Organization = Organization(),
                    Name = "Test Supplier 1",
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                },
                new Supplier
                {
                    Organization = Organization(),
                    Name = "Test Supplier 2",
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static TaskStatus TaskStatus()
        {
            return new TaskStatus
            {
                Name = "Test Task Status",
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.User(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.User(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static Task Task()
        {
            return new Task
            {
                Name = "Test Task",
                Description = "Test Task Description",
                AssignedTo = Employee(),
                AssignedBy = Employee(),
                EstimatedStart = DateTime.Now,
                EstimatedEnd = DateTime.Now.AddDays(10),
                ActualStart = DateTime.Now,
                ActualEnd = DateTime.Now.AddDays(5),
                Status = TaskStatus(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.User(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.User(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<Task> Tasks()
        {
            return new List<Task>
            {
                new Task
                {
                    Name = "Test Task",
                    Description = "Test Task Description",
                    AssignedTo = Employee(),
                    AssignedBy = Employee(),
                    EstimatedStart = DateTime.Now,
                    EstimatedEnd = DateTime.Now.AddDays(10),
                    ActualStart = DateTime.Now,
                    ActualEnd = DateTime.Now.AddDays(5),
                    Status = TaskStatus(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                },
                new Task
                {
                    Name = "Test Task",
                    Description = "Test Task Description",
                    AssignedTo = Employee(),
                    AssignedBy = Employee(),
                    EstimatedStart = DateTime.Now,
                    EstimatedEnd = DateTime.Now.AddDays(10),
                    ActualStart = DateTime.Now,
                    ActualEnd = DateTime.Now.AddDays(5),
                    Status = TaskStatus(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }

        public static Workflow Workflow()
        {
            return new Workflow
            {
                Name = "Test Workflow Process",
                Description = "Test Workflow Process Description",
                Department = OrganizationDepartment(),
                Employees = Employees(),
                Tasks = Tasks(),
                Created = DateTime.Now,
                CreatedBy = Core.Tests.TestHelper.User(),
                Modified = DateTime.Now,
                ModifiedBy = Core.Tests.TestHelper.User(),
                IsActive = true,
                IsDeleted = false
            };
        }

        public static List<Workflow> Workflows()
        {
            return new List<Workflow>
            {
                new Workflow
                {
                    Name = "Test Workflow Process",
                    Description = "Test Workflow Process Description",
                    Department = OrganizationDepartment(),
                    Employees = Employees(),
                    Tasks = Tasks(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                },
                new Workflow
                {
                    Name = "Test Workflow Process",
                    Description = "Test Workflow Process Description",
                    Department = OrganizationDepartment(),
                    Employees = Employees(),
                    Tasks = Tasks(),
                    Created = DateTime.Now,
                    CreatedBy = Core.Tests.TestHelper.User(),
                    Modified = DateTime.Now,
                    ModifiedBy = Core.Tests.TestHelper.User(),
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }
    }
}