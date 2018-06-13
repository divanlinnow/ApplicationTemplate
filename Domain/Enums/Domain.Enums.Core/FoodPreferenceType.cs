using System.ComponentModel;

namespace Domain.Enums.Core
{
    public enum FoodPreferenceType
    {
        [Description("Unknown")]
        Unknown = 0,

        [Description("No Preference")]
        No_Preference = 1,

        [Description("Dairy-Free")]
        Dairy_Free = 2,

        [Description("Diabetic")]
        Diabetic = 3,

        [Description("Gluten-Free")]
        Gluten_Free = 4,

        [Description("Halaal")]
        Halaal = 5,

        [Description("Kosher")]
        Kosher = 6,

        [Description("Lactose-Free")]
        Lactose_Free = 7,

        [Description("Peanut-Free")]
        Peanut_Free = 8,

        [Description("Vegan")]
        Vegan = 9,

        [Description("Vegetarian")]
        Vegetarian = 10,

        [Description("Pescetarian")]
        Pescetarian = 11
    }
}