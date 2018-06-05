using System.ComponentModel;

namespace Domain.Enums.Core
{
    public enum BloodType
    {
        [Description("Unknown")]
        Unknown = 0,

        [Description("A+")]
        A_Positive = 1,

        [Description("A-")]
        A_Negative = 2,

        [Description("B+")]
        B_Positive = 3,

        [Description("B-")]
        B_Negative = 4,

        [Description("AB+")]
        AB_Positive = 5,

        [Description("AB-")]
        AB_Negative = 6,

        [Description("O+")]
        O_Positive = 7,

        [Description("O-")]
        O_Negative = 8
    }
}