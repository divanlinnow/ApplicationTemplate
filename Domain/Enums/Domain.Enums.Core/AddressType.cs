using System.ComponentModel;

namespace Domain.Enums.Core
{
    public enum AddressType
    {
        [Description("Legal")]
        Legal = 0,

        [Description("Work")]
        Work = 1,

        [Description("Home")]
        Home = 2,
        
        [Description("Postal")]
        Postal = 3,

        [Description("Branch")]
        Branch = 4,

        [Description("Delivery")]
        Delivery = 5,

        [Description("Collection")]
        Collection = 6,

        [Description("Other")]
        Other = 7
    }
}