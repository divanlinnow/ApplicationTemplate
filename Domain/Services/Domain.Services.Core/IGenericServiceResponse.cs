using ApplicationFramework.Notifications;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface IGenericServiceResponse
    {
       NotificationCollection Notifications { get; set; }
    }
}