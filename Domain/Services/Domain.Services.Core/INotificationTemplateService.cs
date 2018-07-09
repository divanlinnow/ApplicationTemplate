using Domain.Models.Core;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface INotificationTemplateService
    {
        GenericServiceResponse<IEnumerable<NotificationTemplateDto>> GetAllNotificationTemplates();

        GenericServiceResponse<NotificationTemplateDto> FindNotificationTemplateById(int Id);

        GenericServiceResponse<bool> CreateNotificationTemplate(NotificationTemplateDto notificationTemplate);

        GenericServiceResponse<bool> UpdateNotificationTemplate(NotificationTemplateDto notificationTemplate);

        GenericServiceResponse<bool> DeleteNotificationTemplate(NotificationTemplateDto notificationTemplate);

        GenericServiceResponse<bool> DeleteNotificationTemplate(int Id);
    }
}