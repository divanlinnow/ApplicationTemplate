using ApplicationFramework.Notifications;

namespace Domain.Services.Core
{
    public class GenericServiceResponse<T> : IGenericServiceResponse
    {
        public GenericServiceResponse()
        {
            Notifications = NotificationCollection.CreateEmpty(); 
        }

        public T Result { get; set; }
        public NotificationCollection Notifications { get; set; }
    }
}