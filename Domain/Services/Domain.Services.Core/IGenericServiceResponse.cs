using ApplicationFramework.Notifications;

namespace Domain.Services.Core
{
    public interface IGenericServiceResponse
    {
       NotificationCollection Notifications { get; set; }
    }
}