using System;

public abstract class ViewModelBase
{
    public NotificationCollection Notifications { get; set; }

    public string StylingContext { get; set; }

    public ViewModelBase()
    {
        Notifications = NotificationCollection.CreateEmpty();
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
