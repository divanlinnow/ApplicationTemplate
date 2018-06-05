using System.ComponentModel;

namespace Domain.Enums.Core
{
    public enum PhoneType
    {
        [Description("Land-line (Home)")]
        LandLineHome = 0,

        [Description("Land-line (Work)")]
        LandLineWork = 1,

        [Description("Mobile (Personal)")]
        MobilePersonal = 2,

        [Description("Mobile (Work)")]
        MobileWork = 3,

        [Description("Fax (Personal)")]
        FaxPersonal = 4,

        [Description("Fax (Work)")]
        FaxWork = 5,

        [Description("Other")]
        Other = 6
    }
}