using System.Globalization;
using System.Runtime.Serialization;

namespace ApplicationFramework.Notifications
{
    [DataContract]
    public class Notification
    {
        #region Properties
        
        [DataMember]
        public NotificationSeverity Severity { get; set; }
        
        [DataMember]
        public string Text { get; set; }
        
        [DataMember]
        public string Code { get; set; }

        #endregion Properties

        #region Constructor

        public Notification(string text)
        {
            Text = text;
            Severity = NotificationSeverity.Information;
        }
        
        public Notification(string text, NotificationSeverity severity)
        {
            Text = text;
            Severity = severity;
        }

        #endregion Constructor

        #region Methods

        public static Notification Create(string message, NotificationSeverity notificationSeverity)
        {
            return new Notification(message, notificationSeverity);
        }

        public static Notification Create(string code, string message, NotificationSeverity notificationSeverity)
        {
            return new Notification(message, notificationSeverity) { Code = code };
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} : {1}", Severity, Text);
        }

        #endregion Methods
    }
}
