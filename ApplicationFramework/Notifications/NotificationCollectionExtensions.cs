using System;

namespace ApplicationFramework.Notifications
{
    public static class NotificationCollectionExtensions
    {
        public static NotificationCollection AddError(this NotificationCollection instance, string error, string errorCode)
        {
            var notification = new Notification(error, NotificationSeverity.Error);

            if (!string.IsNullOrEmpty(errorCode))
            {
                notification.Code = errorCode;
            }

            instance.AddMessage(notification);

            return instance;
        }

        public static NotificationCollection AddException(this NotificationCollection instance, Exception exception)
        {
            return instance.AddError(exception.Message);
        }

        public static NotificationCollection AddError(this NotificationCollection instance, string error)
        {
            return instance.AddError(error, string.Empty);
        }
    }
}
