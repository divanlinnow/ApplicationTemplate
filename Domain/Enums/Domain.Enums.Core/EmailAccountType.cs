using System.ComponentModel;

namespace Domain.Enums.Core
{
    public enum EmailAccountType
    {
        [Description("POP3")]
        POP3 = 0,

        [Description("IMAP")]
        IMAP = 1
    }
}