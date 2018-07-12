namespace ORM.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "AppTemplate.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        AddressLine1 = c.String(nullable: false, maxLength: 100),
                        AddressLine2 = c.String(maxLength: 100),
                        AddressLine3 = c.String(maxLength: 100),
                        Suburb = c.String(maxLength: 100),
                        PostalCode = c.String(maxLength: 20),
                        Latitude = c.Decimal(precision: 9, scale: 3),
                        Longitude = c.Decimal(precision: 9, scale: 3),
                        PriorityOrder = c.Short(),
                        Created = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        Country_ID = c.Int(),
                        User_ID = c.Int(),
                        Province_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Countries", t => t.Country_ID)
                .ForeignKey("AppTemplate.Users", t => t.User_ID)
                .ForeignKey("AppTemplate.Provinces", t => t.Province_ID)
                .Index(t => t.Type, name: "Address_Type")
                .Index(t => t.IsDeleted, name: "Address_IsDeleted")
                .Index(t => t.Country_ID)
                .Index(t => t.User_ID)
                .Index(t => t.Province_ID);
            
            CreateTable(
                "AppTemplate.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ISOCode = c.String(nullable: false, maxLength: 3, unicode: false),
                        Abbreviation = c.String(maxLength: 5, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Country_ID = c.Int(),
                        Province_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Countries", t => t.Country_ID)
                .ForeignKey("AppTemplate.Provinces", t => t.Province_ID, cascadeDelete: true)
                .ForeignKey("AppTemplate.Addresses", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.ISOCode, name: "City_ISOCode")
                .Index(t => t.Abbreviation, name: "City_Abbreviation")
                .Index(t => t.Name, name: "City_Name")
                .Index(t => t.Country_ID)
                .Index(t => t.Province_ID);
            
            CreateTable(
                "AppTemplate.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ISOCode = c.String(nullable: false, maxLength: 3, unicode: false),
                        Abbreviation = c.String(maxLength: 5, unicode: false),
                        Name = c.String(nullable: false, maxLength: 55),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.ISOCode, name: "Country_ISOCode")
                .Index(t => t.Abbreviation, name: "Country_Abbreviation")
                .Index(t => t.Name, name: "Country_Name");
            
            CreateTable(
                "AppTemplate.Provinces",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ISOCode = c.String(nullable: false, maxLength: 3, unicode: false),
                        Abbreviation = c.String(maxLength: 5, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Country_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Countries", t => t.Country_ID, cascadeDelete: true)
                .Index(t => t.ISOCode, name: "Province_ISOCode")
                .Index(t => t.Abbreviation, name: "Province_Abbreviation")
                .Index(t => t.Name, name: "Province_Name")
                .Index(t => t.Country_ID);
            
            CreateTable(
                "AppTemplate.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Prefix = c.Int(),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Suffix = c.Int(),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 500, unicode: false),
                        Salt = c.String(nullable: false, maxLength: 500, unicode: false),
                        Type = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        BloodType = c.Int(nullable: false),
                        FoodPreferenceType = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Created = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsConfirmed = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        User_ID = c.Int(nullable: false),
                        User_ID1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Users", t => t.User_ID)
                .ForeignKey("AppTemplate.EmailAddresses", t => t.ID)
                .ForeignKey("AppTemplate.Users", t => t.User_ID1)
                .ForeignKey("AppTemplate.PhoneNumbers", t => t.ID)
                .ForeignKey("AppTemplate.Addresses", t => t.ID)
                .ForeignKey("AppTemplate.NotificationTemplates", t => t.ID)
                .ForeignKey("AppTemplate.Orders", t => t.ID)
                .ForeignKey("AppTemplate.Customers", t => t.ID)
                .ForeignKey("AppTemplate.OrganizationBranches", t => t.ID)
                .ForeignKey("AppTemplate.OrganizationDepartments", t => t.ID)
                .ForeignKey("AppTemplate.Organizations", t => t.ID)
                .ForeignKey("AppTemplate.Jobs", t => t.ID)
                .ForeignKey("AppTemplate.Products", t => t.ID)
                .ForeignKey("AppTemplate.Suppliers", t => t.ID)
                .ForeignKey("AppTemplate.Services", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.UserName, name: "User_UserName")
                .Index(t => t.Type, name: "User_Type")
                .Index(t => t.Status, name: "User_Status")
                .Index(t => t.BloodType, name: "User_BloodType")
                .Index(t => t.FoodPreferenceType, name: "User_FoodPreferenceType")
                .Index(t => t.IsConfirmed, name: "User_IsConfirmed")
                .Index(t => t.IsDeleted, name: "User_IsDeleted")
                .Index(t => t.User_ID)
                .Index(t => t.User_ID1);
            
            CreateTable(
                "AppTemplate.EmailAddresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        AccountType = c.Int(nullable: false),
                        EmailAddress = c.String(nullable: false, maxLength: 320),
                        IncomingMailServer = c.String(nullable: false, maxLength: 100),
                        OutgoingMailServer = c.String(nullable: false, maxLength: 100),
                        IncomingMailServerPort = c.Int(nullable: false),
                        OutgoingMailServerPort = c.Int(nullable: false),
                        IncomingServerUseSSL = c.Boolean(nullable: false),
                        OutgoingServerUseSSL = c.Boolean(nullable: false),
                        PriorityOrder = c.Short(),
                        Created = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Users", t => t.User_ID)
                .Index(t => t.Type, name: "Email_Type")
                .Index(t => t.AccountType, name: "Email_AccountType")
                .Index(t => t.EmailAddress, name: "EmailAddress")
                .Index(t => t.IsDeleted, name: "Email_IsDeleted")
                .Index(t => t.User_ID);
            
            CreateTable(
                "AppTemplate.Languages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ISOCode = c.String(nullable: false, maxLength: 3, unicode: false),
                        Abbreviation = c.String(maxLength: 5, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Users", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.ISOCode, name: "Language_ISOCode")
                .Index(t => t.Abbreviation, name: "Language_Abbreviation")
                .Index(t => t.Name, name: "Language_Name");
            
            CreateTable(
                "AppTemplate.PhoneNumbers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Number = c.String(maxLength: 15, unicode: false),
                        PriorityOrder = c.Short(),
                        Created = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Users", t => t.User_ID)
                .Index(t => t.Type, name: "PhoneNumber_Type")
                .Index(t => t.Number, name: "PhoneNumber")
                .Index(t => t.IsDeleted, name: "PhoneNumber_IsDeleted")
                .Index(t => t.User_ID);
            
            CreateTable(
                "AppTemplate.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Users", t => t.User_ID)
                .ForeignKey("AppTemplate.Jobs", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.Name, name: "Role_Name")
                .Index(t => t.IsActive, name: "Role_IsActive")
                .Index(t => t.IsDeleted, name: "Role_IsDeleted")
                .Index(t => t.User_ID);
            
            CreateTable(
                "AppTemplate.Permissions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Roles", t => t.Role_ID)
                .Index(t => t.Name, name: "Permission_Name")
                .Index(t => t.IsActive, name: "Permission_IsActive")
                .Index(t => t.IsDeleted, name: "Permission_IsDeleted")
                .Index(t => t.Role_ID);
            
            CreateTable(
                "AppTemplate.NotificationTemplates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        SubjectHeader = c.String(nullable: false, maxLength: 50),
                        Body = c.String(nullable: false, maxLength: 1000),
                        Created = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, name: "NotificationTemplate_Name")
                .Index(t => t.IsActive, name: "NotificationTemplate_IsActive")
                .Index(t => t.IsDeleted, name: "NotificationTemplate_IsDeleted");
            
            CreateTable(
                "AppTemplate.Currencies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ISOCode = c.String(nullable: false, maxLength: 3, unicode: false),
                        Abbreviation = c.String(maxLength: 5, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.ISOCode, name: "Currency_ISOCode")
                .Index(t => t.Abbreviation, name: "Currency_Abbreviation")
                .Index(t => t.Name, name: "Currency_Name");
            
            CreateTable(
                "AppTemplate.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreditBlocked = c.Boolean(nullable: false),
                        CreditLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AllowancePeriod_Days = c.Short(nullable: false),
                        AllowancePeriod_Months = c.Short(nullable: false),
                        IsPreferredCustomer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Orders", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "AppTemplate.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlacementDate = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        TrackingNumber = c.String(nullable: false, maxLength: 50),
                        Created = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsForCollection = c.Boolean(nullable: false),
                        IsForDelivery = c.Boolean(nullable: false),
                        IsQuote = c.Boolean(nullable: false),
                        IsCancelled = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CollectionAddress_ID = c.Int(),
                        DeliveryAddress_ID = c.Int(),
                        Customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Addresses", t => t.CollectionAddress_ID)
                .ForeignKey("AppTemplate.Addresses", t => t.DeliveryAddress_ID)
                .ForeignKey("AppTemplate.Customers", t => t.Customer_ID)
                .Index(t => t.PlacementDate, name: "Order_PlacementDate")
                .Index(t => t.TrackingNumber, name: "Order_TrackingNumber")
                .Index(t => t.IsActive, name: "Order_IsActive")
                .Index(t => t.IsDeleted, name: "Order_IsDeleted")
                .Index(t => t.CollectionAddress_ID)
                .Index(t => t.DeliveryAddress_ID)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "AppTemplate.ProductOrderItem",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("AppTemplate.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "AppTemplate.ServiceOrderItem",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ServiceId })
                .ForeignKey("AppTemplate.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "AppTemplate.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Created = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.IsActive, name: "Job_IsActive")
                .Index(t => t.IsDeleted, name: "Job_IsDeleted");
            
            CreateTable(
                "AppTemplate.OrganizationBranches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Created = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        Address_ID = c.Int(),
                        Organization_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Addresses", t => t.Address_ID)
                .ForeignKey("AppTemplate.OrganizationDepartments", t => t.ID)
                .ForeignKey("AppTemplate.Organizations", t => t.Organization_ID)
                .ForeignKey("AppTemplate.Jobs", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.Name, name: "OrganizationBranch_PrintName")
                .Index(t => t.IsDeleted, name: "OrganizationBranch_IsDeleted")
                .Index(t => t.Address_ID)
                .Index(t => t.Organization_ID);
            
            CreateTable(
                "AppTemplate.OrganizationDepartments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Created = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Address_ID = c.Int(),
                        OrganizationBranch_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Addresses", t => t.Address_ID)
                .ForeignKey("AppTemplate.OrganizationBranches", t => t.OrganizationBranch_ID)
                .ForeignKey("AppTemplate.Jobs", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.IsActive, name: "OrganizationDepartment_IsActive")
                .Index(t => t.IsDeleted, name: "OrganizationDepartment_IsDeleted")
                .Index(t => t.Address_ID)
                .Index(t => t.OrganizationBranch_ID);
            
            CreateTable(
                "AppTemplate.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Branch_ID = c.Int(),
                        Job_ID = c.Int(),
                        Organization_ID = c.Int(),
                        User_ID = c.Int(),
                        Department_ID = c.Int(),
                        Workflow_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.OrganizationBranches", t => t.Branch_ID)
                .ForeignKey("AppTemplate.Jobs", t => t.Job_ID)
                .ForeignKey("AppTemplate.Organizations", t => t.Organization_ID)
                .ForeignKey("AppTemplate.Users", t => t.User_ID)
                .ForeignKey("AppTemplate.OrganizationDepartments", t => t.Department_ID)
                .ForeignKey("AppTemplate.WorkflowProcesses", t => t.Workflow_ID)
                .Index(t => t.Branch_ID)
                .Index(t => t.Job_ID)
                .Index(t => t.Organization_ID)
                .Index(t => t.User_ID)
                .Index(t => t.Department_ID)
                .Index(t => t.Workflow_ID);
            
            CreateTable(
                "AppTemplate.Organizations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegisteredName = c.String(nullable: false, maxLength: 50),
                        PrintName = c.String(nullable: false, maxLength: 50),
                        Created = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsRegistered = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.OrganizationDepartments", t => t.ID)
                .ForeignKey("AppTemplate.OrganizationBranches", t => t.ID)
                .ForeignKey("AppTemplate.Jobs", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.IsRegistered, name: "Organization_IsRegistered")
                .Index(t => t.IsActive, name: "Organization_IsActive")
                .Index(t => t.IsDeleted, name: "Organization_IsDeleted");
            
            CreateTable(
                "AppTemplate.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Make = c.String(nullable: false, maxLength: 50),
                        Model = c.String(nullable: false, maxLength: 50),
                        Year = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                        MinimumOrderQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceEXCL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceINCL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceMustChange = c.Boolean(nullable: false),
                        PriceExpiryDate = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        HasExpiryDate = c.Boolean(nullable: false),
                        ExpiryDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        Created = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Supplier_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Suppliers", t => t.Supplier_ID)
                .Index(t => t.IsActive, name: "Product_IsActive")
                .Index(t => t.IsDeleted, name: "Product_IsDeleted")
                .Index(t => t.Supplier_ID);
            
            CreateTable(
                "AppTemplate.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(),
                        Organization_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Organizations", t => t.Organization_ID)
                .Index(t => t.IsActive, name: "Supplier_IsActive")
                .Index(t => t.IsDeleted, name: "Supplier_IsDeleted")
                .Index(t => t.Organization_ID);
            
            CreateTable(
                "AppTemplate.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 1000),
                        MinimumOrderQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceEXCL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceINCL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceMustChange = c.Boolean(nullable: false),
                        PriceExpiryDate = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        HasExpiryDate = c.Boolean(nullable: false),
                        ExpiryDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        Created = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Supplier_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Suppliers", t => t.Supplier_ID)
                .Index(t => t.IsActive, name: "Service_IsActive")
                .Index(t => t.IsDeleted, name: "Service_IsDeleted")
                .Index(t => t.Supplier_ID);
            
            CreateTable(
                "AppTemplate.Tasks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        EstimatedStart = c.DateTime(nullable: false),
                        EstimatedEnd = c.DateTime(nullable: false),
                        ActualStart = c.DateTime(nullable: false),
                        ActualEnd = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        AssignedBy_ID = c.Int(),
                        AssignedTo_ID = c.Int(),
                        CreatedBy_ID = c.Int(),
                        ModifiedBy_ID = c.Int(),
                        Status_ID = c.Int(),
                        Workflow_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Employee", t => t.AssignedBy_ID)
                .ForeignKey("AppTemplate.Employee", t => t.AssignedTo_ID)
                .ForeignKey("AppTemplate.Users", t => t.CreatedBy_ID)
                .ForeignKey("AppTemplate.Users", t => t.ModifiedBy_ID)
                .ForeignKey("AppTemplate.TaskStatuses", t => t.Status_ID)
                .ForeignKey("AppTemplate.WorkflowProcesses", t => t.Workflow_ID)
                .Index(t => t.AssignedBy_ID)
                .Index(t => t.AssignedTo_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.ModifiedBy_ID)
                .Index(t => t.Status_ID)
                .Index(t => t.Workflow_ID);
            
            CreateTable(
                "AppTemplate.TaskStatuses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy_ID = c.Int(),
                        ModifiedBy_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Users", t => t.CreatedBy_ID)
                .ForeignKey("AppTemplate.Users", t => t.ModifiedBy_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.ModifiedBy_ID);
            
            CreateTable(
                "AppTemplate.WorkflowProcesses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy_ID = c.Int(),
                        Department_ID = c.Int(),
                        ModifiedBy_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("AppTemplate.Users", t => t.CreatedBy_ID)
                .ForeignKey("AppTemplate.OrganizationDepartments", t => t.Department_ID)
                .ForeignKey("AppTemplate.Users", t => t.ModifiedBy_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.Department_ID)
                .Index(t => t.ModifiedBy_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("AppTemplate.Tasks", "Workflow_ID", "AppTemplate.WorkflowProcesses");
            DropForeignKey("AppTemplate.WorkflowProcesses", "ModifiedBy_ID", "AppTemplate.Users");
            DropForeignKey("AppTemplate.Employee", "Workflow_ID", "AppTemplate.WorkflowProcesses");
            DropForeignKey("AppTemplate.WorkflowProcesses", "Department_ID", "AppTemplate.OrganizationDepartments");
            DropForeignKey("AppTemplate.WorkflowProcesses", "CreatedBy_ID", "AppTemplate.Users");
            DropForeignKey("AppTemplate.Tasks", "Status_ID", "AppTemplate.TaskStatuses");
            DropForeignKey("AppTemplate.TaskStatuses", "ModifiedBy_ID", "AppTemplate.Users");
            DropForeignKey("AppTemplate.TaskStatuses", "CreatedBy_ID", "AppTemplate.Users");
            DropForeignKey("AppTemplate.Tasks", "ModifiedBy_ID", "AppTemplate.Users");
            DropForeignKey("AppTemplate.Tasks", "CreatedBy_ID", "AppTemplate.Users");
            DropForeignKey("AppTemplate.Tasks", "AssignedTo_ID", "AppTemplate.Employee");
            DropForeignKey("AppTemplate.Tasks", "AssignedBy_ID", "AppTemplate.Employee");
            DropForeignKey("AppTemplate.Services", "Supplier_ID", "AppTemplate.Suppliers");
            DropForeignKey("AppTemplate.Users", "ID", "AppTemplate.Services");
            DropForeignKey("AppTemplate.Products", "Supplier_ID", "AppTemplate.Suppliers");
            DropForeignKey("AppTemplate.Suppliers", "Organization_ID", "AppTemplate.Organizations");
            DropForeignKey("AppTemplate.Users", "ID", "AppTemplate.Suppliers");
            DropForeignKey("AppTemplate.Users", "ID", "AppTemplate.Products");
            DropForeignKey("AppTemplate.Roles", "ID", "AppTemplate.Jobs");
            DropForeignKey("AppTemplate.Organizations", "ID", "AppTemplate.Jobs");
            DropForeignKey("AppTemplate.OrganizationDepartments", "ID", "AppTemplate.Jobs");
            DropForeignKey("AppTemplate.Users", "ID", "AppTemplate.Jobs");
            DropForeignKey("AppTemplate.OrganizationBranches", "ID", "AppTemplate.Jobs");
            DropForeignKey("AppTemplate.Organizations", "ID", "AppTemplate.OrganizationBranches");
            DropForeignKey("AppTemplate.OrganizationDepartments", "OrganizationBranch_ID", "AppTemplate.OrganizationBranches");
            DropForeignKey("AppTemplate.Organizations", "ID", "AppTemplate.OrganizationDepartments");
            DropForeignKey("AppTemplate.Employee", "Department_ID", "AppTemplate.OrganizationDepartments");
            DropForeignKey("AppTemplate.Employee", "User_ID", "AppTemplate.Users");
            DropForeignKey("AppTemplate.Employee", "Organization_ID", "AppTemplate.Organizations");
            DropForeignKey("AppTemplate.Users", "ID", "AppTemplate.Organizations");
            DropForeignKey("AppTemplate.OrganizationBranches", "Organization_ID", "AppTemplate.Organizations");
            DropForeignKey("AppTemplate.Employee", "Job_ID", "AppTemplate.Jobs");
            DropForeignKey("AppTemplate.Employee", "Branch_ID", "AppTemplate.OrganizationBranches");
            DropForeignKey("AppTemplate.Users", "ID", "AppTemplate.OrganizationDepartments");
            DropForeignKey("AppTemplate.OrganizationBranches", "ID", "AppTemplate.OrganizationDepartments");
            DropForeignKey("AppTemplate.OrganizationDepartments", "Address_ID", "AppTemplate.Addresses");
            DropForeignKey("AppTemplate.Users", "ID", "AppTemplate.OrganizationBranches");
            DropForeignKey("AppTemplate.OrganizationBranches", "Address_ID", "AppTemplate.Addresses");
            DropForeignKey("AppTemplate.Users", "ID", "AppTemplate.Customers");
            DropForeignKey("AppTemplate.Orders", "Customer_ID", "AppTemplate.Customers");
            DropForeignKey("AppTemplate.ServiceOrderItem", "OrderId", "AppTemplate.Orders");
            DropForeignKey("AppTemplate.ProductOrderItem", "OrderId", "AppTemplate.Orders");
            DropForeignKey("AppTemplate.Orders", "DeliveryAddress_ID", "AppTemplate.Addresses");
            DropForeignKey("AppTemplate.Customers", "ID", "AppTemplate.Orders");
            DropForeignKey("AppTemplate.Users", "ID", "AppTemplate.Orders");
            DropForeignKey("AppTemplate.Orders", "CollectionAddress_ID", "AppTemplate.Addresses");
            DropForeignKey("AppTemplate.Users", "ID", "AppTemplate.NotificationTemplates");
            DropForeignKey("AppTemplate.Addresses", "Province_ID", "AppTemplate.Provinces");
            DropForeignKey("AppTemplate.Users", "ID", "AppTemplate.Addresses");
            DropForeignKey("AppTemplate.Roles", "User_ID", "AppTemplate.Users");
            DropForeignKey("AppTemplate.Permissions", "Role_ID", "AppTemplate.Roles");
            DropForeignKey("AppTemplate.PhoneNumbers", "User_ID", "AppTemplate.Users");
            DropForeignKey("AppTemplate.Users", "ID", "AppTemplate.PhoneNumbers");
            DropForeignKey("AppTemplate.Users", "User_ID1", "AppTemplate.Users");
            DropForeignKey("AppTemplate.Languages", "ID", "AppTemplate.Users");
            DropForeignKey("AppTemplate.EmailAddresses", "User_ID", "AppTemplate.Users");
            DropForeignKey("AppTemplate.Users", "ID", "AppTemplate.EmailAddresses");
            DropForeignKey("AppTemplate.Users", "User_ID", "AppTemplate.Users");
            DropForeignKey("AppTemplate.Addresses", "User_ID", "AppTemplate.Users");
            DropForeignKey("AppTemplate.Addresses", "Country_ID", "AppTemplate.Countries");
            DropForeignKey("AppTemplate.Cities", "ID", "AppTemplate.Addresses");
            DropForeignKey("AppTemplate.Cities", "Province_ID", "AppTemplate.Provinces");
            DropForeignKey("AppTemplate.Cities", "Country_ID", "AppTemplate.Countries");
            DropForeignKey("AppTemplate.Provinces", "Country_ID", "AppTemplate.Countries");
            DropIndex("AppTemplate.WorkflowProcesses", new[] { "ModifiedBy_ID" });
            DropIndex("AppTemplate.WorkflowProcesses", new[] { "Department_ID" });
            DropIndex("AppTemplate.WorkflowProcesses", new[] { "CreatedBy_ID" });
            DropIndex("AppTemplate.TaskStatuses", new[] { "ModifiedBy_ID" });
            DropIndex("AppTemplate.TaskStatuses", new[] { "CreatedBy_ID" });
            DropIndex("AppTemplate.Tasks", new[] { "Workflow_ID" });
            DropIndex("AppTemplate.Tasks", new[] { "Status_ID" });
            DropIndex("AppTemplate.Tasks", new[] { "ModifiedBy_ID" });
            DropIndex("AppTemplate.Tasks", new[] { "CreatedBy_ID" });
            DropIndex("AppTemplate.Tasks", new[] { "AssignedTo_ID" });
            DropIndex("AppTemplate.Tasks", new[] { "AssignedBy_ID" });
            DropIndex("AppTemplate.Services", new[] { "Supplier_ID" });
            DropIndex("AppTemplate.Services", "Service_IsDeleted");
            DropIndex("AppTemplate.Services", "Service_IsActive");
            DropIndex("AppTemplate.Suppliers", new[] { "Organization_ID" });
            DropIndex("AppTemplate.Suppliers", "Supplier_IsDeleted");
            DropIndex("AppTemplate.Suppliers", "Supplier_IsActive");
            DropIndex("AppTemplate.Products", new[] { "Supplier_ID" });
            DropIndex("AppTemplate.Products", "Product_IsDeleted");
            DropIndex("AppTemplate.Products", "Product_IsActive");
            DropIndex("AppTemplate.Organizations", "Organization_IsDeleted");
            DropIndex("AppTemplate.Organizations", "Organization_IsActive");
            DropIndex("AppTemplate.Organizations", "Organization_IsRegistered");
            DropIndex("AppTemplate.Organizations", new[] { "ID" });
            DropIndex("AppTemplate.Employee", new[] { "Workflow_ID" });
            DropIndex("AppTemplate.Employee", new[] { "Department_ID" });
            DropIndex("AppTemplate.Employee", new[] { "User_ID" });
            DropIndex("AppTemplate.Employee", new[] { "Organization_ID" });
            DropIndex("AppTemplate.Employee", new[] { "Job_ID" });
            DropIndex("AppTemplate.Employee", new[] { "Branch_ID" });
            DropIndex("AppTemplate.OrganizationDepartments", new[] { "OrganizationBranch_ID" });
            DropIndex("AppTemplate.OrganizationDepartments", new[] { "Address_ID" });
            DropIndex("AppTemplate.OrganizationDepartments", "OrganizationDepartment_IsDeleted");
            DropIndex("AppTemplate.OrganizationDepartments", "OrganizationDepartment_IsActive");
            DropIndex("AppTemplate.OrganizationDepartments", new[] { "ID" });
            DropIndex("AppTemplate.OrganizationBranches", new[] { "Organization_ID" });
            DropIndex("AppTemplate.OrganizationBranches", new[] { "Address_ID" });
            DropIndex("AppTemplate.OrganizationBranches", "OrganizationBranch_IsDeleted");
            DropIndex("AppTemplate.OrganizationBranches", "OrganizationBranch_PrintName");
            DropIndex("AppTemplate.OrganizationBranches", new[] { "ID" });
            DropIndex("AppTemplate.Jobs", "Job_IsDeleted");
            DropIndex("AppTemplate.Jobs", "Job_IsActive");
            DropIndex("AppTemplate.ServiceOrderItem", new[] { "OrderId" });
            DropIndex("AppTemplate.ProductOrderItem", new[] { "OrderId" });
            DropIndex("AppTemplate.Orders", new[] { "Customer_ID" });
            DropIndex("AppTemplate.Orders", new[] { "DeliveryAddress_ID" });
            DropIndex("AppTemplate.Orders", new[] { "CollectionAddress_ID" });
            DropIndex("AppTemplate.Orders", "Order_IsDeleted");
            DropIndex("AppTemplate.Orders", "Order_IsActive");
            DropIndex("AppTemplate.Orders", "Order_TrackingNumber");
            DropIndex("AppTemplate.Orders", "Order_PlacementDate");
            DropIndex("AppTemplate.Customers", new[] { "ID" });
            DropIndex("AppTemplate.Currencies", "Currency_Name");
            DropIndex("AppTemplate.Currencies", "Currency_Abbreviation");
            DropIndex("AppTemplate.Currencies", "Currency_ISOCode");
            DropIndex("AppTemplate.NotificationTemplates", "NotificationTemplate_IsDeleted");
            DropIndex("AppTemplate.NotificationTemplates", "NotificationTemplate_IsActive");
            DropIndex("AppTemplate.NotificationTemplates", "NotificationTemplate_Name");
            DropIndex("AppTemplate.Permissions", new[] { "Role_ID" });
            DropIndex("AppTemplate.Permissions", "Permission_IsDeleted");
            DropIndex("AppTemplate.Permissions", "Permission_IsActive");
            DropIndex("AppTemplate.Permissions", "Permission_Name");
            DropIndex("AppTemplate.Roles", new[] { "User_ID" });
            DropIndex("AppTemplate.Roles", "Role_IsDeleted");
            DropIndex("AppTemplate.Roles", "Role_IsActive");
            DropIndex("AppTemplate.Roles", "Role_Name");
            DropIndex("AppTemplate.Roles", new[] { "ID" });
            DropIndex("AppTemplate.PhoneNumbers", new[] { "User_ID" });
            DropIndex("AppTemplate.PhoneNumbers", "PhoneNumber_IsDeleted");
            DropIndex("AppTemplate.PhoneNumbers", "PhoneNumber");
            DropIndex("AppTemplate.PhoneNumbers", "PhoneNumber_Type");
            DropIndex("AppTemplate.Languages", "Language_Name");
            DropIndex("AppTemplate.Languages", "Language_Abbreviation");
            DropIndex("AppTemplate.Languages", "Language_ISOCode");
            DropIndex("AppTemplate.Languages", new[] { "ID" });
            DropIndex("AppTemplate.EmailAddresses", new[] { "User_ID" });
            DropIndex("AppTemplate.EmailAddresses", "Email_IsDeleted");
            DropIndex("AppTemplate.EmailAddresses", "EmailAddress");
            DropIndex("AppTemplate.EmailAddresses", "Email_AccountType");
            DropIndex("AppTemplate.EmailAddresses", "Email_Type");
            DropIndex("AppTemplate.Users", new[] { "User_ID1" });
            DropIndex("AppTemplate.Users", new[] { "User_ID" });
            DropIndex("AppTemplate.Users", "User_IsDeleted");
            DropIndex("AppTemplate.Users", "User_IsConfirmed");
            DropIndex("AppTemplate.Users", "User_FoodPreferenceType");
            DropIndex("AppTemplate.Users", "User_BloodType");
            DropIndex("AppTemplate.Users", "User_Status");
            DropIndex("AppTemplate.Users", "User_Type");
            DropIndex("AppTemplate.Users", "User_UserName");
            DropIndex("AppTemplate.Users", new[] { "ID" });
            DropIndex("AppTemplate.Provinces", new[] { "Country_ID" });
            DropIndex("AppTemplate.Provinces", "Province_Name");
            DropIndex("AppTemplate.Provinces", "Province_Abbreviation");
            DropIndex("AppTemplate.Provinces", "Province_ISOCode");
            DropIndex("AppTemplate.Countries", "Country_Name");
            DropIndex("AppTemplate.Countries", "Country_Abbreviation");
            DropIndex("AppTemplate.Countries", "Country_ISOCode");
            DropIndex("AppTemplate.Cities", new[] { "Province_ID" });
            DropIndex("AppTemplate.Cities", new[] { "Country_ID" });
            DropIndex("AppTemplate.Cities", "City_Name");
            DropIndex("AppTemplate.Cities", "City_Abbreviation");
            DropIndex("AppTemplate.Cities", "City_ISOCode");
            DropIndex("AppTemplate.Cities", new[] { "ID" });
            DropIndex("AppTemplate.Addresses", new[] { "Province_ID" });
            DropIndex("AppTemplate.Addresses", new[] { "User_ID" });
            DropIndex("AppTemplate.Addresses", new[] { "Country_ID" });
            DropIndex("AppTemplate.Addresses", "Address_IsDeleted");
            DropIndex("AppTemplate.Addresses", "Address_Type");
            DropTable("AppTemplate.WorkflowProcesses");
            DropTable("AppTemplate.TaskStatuses");
            DropTable("AppTemplate.Tasks");
            DropTable("AppTemplate.Services");
            DropTable("AppTemplate.Suppliers");
            DropTable("AppTemplate.Products");
            DropTable("AppTemplate.Organizations");
            DropTable("AppTemplate.Employee");
            DropTable("AppTemplate.OrganizationDepartments");
            DropTable("AppTemplate.OrganizationBranches");
            DropTable("AppTemplate.Jobs");
            DropTable("AppTemplate.ServiceOrderItem");
            DropTable("AppTemplate.ProductOrderItem");
            DropTable("AppTemplate.Orders");
            DropTable("AppTemplate.Customers");
            DropTable("AppTemplate.Currencies");
            DropTable("AppTemplate.NotificationTemplates");
            DropTable("AppTemplate.Permissions");
            DropTable("AppTemplate.Roles");
            DropTable("AppTemplate.PhoneNumbers");
            DropTable("AppTemplate.Languages");
            DropTable("AppTemplate.EmailAddresses");
            DropTable("AppTemplate.Users");
            DropTable("AppTemplate.Provinces");
            DropTable("AppTemplate.Countries");
            DropTable("AppTemplate.Cities");
            DropTable("AppTemplate.Addresses");
        }
    }
}
