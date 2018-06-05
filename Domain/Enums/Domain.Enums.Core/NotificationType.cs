using System.ComponentModel;

namespace Domain.Enums.Core
{
    public enum NotificationType
    {
        [Description("Application")]
        Application = 0,

        [Description("E-mail")]
        Email = 1,

        [Description("Text/SMS")]
        Text = 2,

        [Description("Phone")]
        Phone = 3,

        [Description("Fax")]
        Fax = 4,

        [Description("Mail")]
        Mail = 5
    }
}