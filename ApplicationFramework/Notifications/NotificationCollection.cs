using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ApplicationFramework.Notifications
{
    [DataContract]
    public class NotificationCollection : IFormattable, IEnumerable<Notification>
    {
        #region Properties

        [DataMember]
        private readonly List<Notification> messages = new List<Notification>();

        #endregion Properties

        #region Methods
        
        public void AddMessage(Notification notification)
        {
            if (notification != null)
            {
                messages.Add(notification);
            }
        }

        public void AddMessage(IEnumerable<Notification> notifications)
        {
            if (notifications != null)
            {
                messages.AddRange(notifications);
            }
        }

        public static NotificationCollection CreateEmpty()
        {
            NotificationCollection notificationCollection = new NotificationCollection();
            return notificationCollection;
        }

        public static NotificationCollection Create(IList<Notification> notifications)
        {
            NotificationCollection notificationCollection = new NotificationCollection();
            notificationCollection.AddMessage(notifications);
            return notificationCollection;
        }
        
        public NotificationCollection Errors()
        {
            var errors = messages.Where(m => m.Severity == NotificationSeverity.Error).ToList();

            var errorCollection = Create(errors);

            return errorCollection;
        }
        
        IEnumerator<Notification> IEnumerable<Notification>.GetEnumerator()
        {
            for (int i = 0; i < messages.Count; i++)
            {
                yield return messages[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Notification>)this).GetEnumerator();
        }
        
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var builder = new StringBuilder();
            foreach (Notification message in messages)
            {
                builder.Append(string.Format(CultureInfo.InvariantCulture, "{0}{1}", builder.Length > 0 ? Environment.NewLine : null, message));
            }
            return builder.ToString();
        }

        #endregion Methods
    }
}
