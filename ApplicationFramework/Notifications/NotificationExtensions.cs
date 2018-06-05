using System.Collections.Generic;
using System.Linq;

namespace ApplicationFramework.Notifications
{
    public static class NotificationExtensions
    {
        public static bool HasMessages(this IEnumerable<Notification> notifications)
        {
            return notifications.Any();
        }

        public static bool HasWarnings(this IEnumerable<Notification> notifications)
        {
            return notifications.Any(n => n.Severity == NotificationSeverity.Warning);
        }

        public static bool HasErrors(this IEnumerable<Notification> notifications)
        {
            return notifications.Any(n => n.Severity == NotificationSeverity.Error);
        }
    }
}
