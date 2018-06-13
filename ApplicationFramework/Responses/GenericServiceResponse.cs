using ApplicationFramework.Notifications;

namespace ApplicationFramework.Responses
{
    public class GenericServiceResponse
    {
        #region Properties

        public NotificationCollection Messages { get; set; }

        #endregion Properties

        #region Constructor

        public GenericServiceResponse()
        {
            Messages = new NotificationCollection();
        }

        #endregion Constructor
    }
}
