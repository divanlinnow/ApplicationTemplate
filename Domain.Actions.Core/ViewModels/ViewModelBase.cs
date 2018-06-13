using ApplicationFramework.Notifications;

namespace Domain.Actions.Core.ViewModels
{
    public abstract class ViewModelBase
    {
        public NotificationCollection Notifications { get; set; }
        
        public ViewModelBase()
        {
            Notifications = new NotificationCollection();
        }

        public bool HasErrors
        {
            get
            {
                return Notifications.HasErrors();
            }
        }

        public bool HasWarnings
        {
            get
            {
                return Notifications.HasWarnings();
            }
        }

        public bool HasMessages
        {
            get
            {
                return Notifications.HasMessages();
            }
        }
    }
}
