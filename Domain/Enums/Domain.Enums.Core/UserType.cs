using System.ComponentModel;

namespace Domain.Enums.Core
{
    public enum UserType
    {
        [Description("System Administrator")]
        System_Administrator = 0,

        [Description("Tenant Administrator")]
        Tenant_Administrator = 1,

        [Description("Organization Administrator")]
        Organization_Administrator = 2,

        [Description("Employee")]
        Employee = 3,

        [Description("Customer (Organization)")]
        Customer_Organization = 4,

        [Description("Customer (Individual)")]
        Customer_Individual = 5,

        [Description("Supplier")]
        Supplier = 6
    }
}