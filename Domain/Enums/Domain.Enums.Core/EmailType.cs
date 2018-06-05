using System.ComponentModel;

namespace Domain.Enums.Core
{
    public enum EmailType
    {
        [Description("Personal")]
        Personal = 0,

        [Description("Work")]
        Work = 1,

        [Description("Test")]
        Test = 2,

        [Description("Other")]
        Other = 3
    }
}