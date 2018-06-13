using System.ComponentModel;

namespace Domain.Enums.Core
{
    public enum UserStatus
    {
        [Description("Off-line")]
        Offline = 0,

        [Description("On-line")]
        Online = 1,

        [Description("Away")]
        Away = 2,

        [Description("Invisible")]
        Invisible = 3,

        [Description("Do Not Disturb")]
        Do_Not_Disturb = 4
    }
}