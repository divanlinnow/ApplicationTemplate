using Domain.Entities.Core;
using Domain.Models.Core;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core
{
    public interface INotificationTemplateService
    {
        GenericServiceResponse<IEnumerable<NotificationTemplateDto>> GetAllNotificationTemplates();

        GenericServiceResponse<NotificationTemplateDto> FindNotificationTemplateById(Guid Id);

        GenericServiceResponse<bool> CreateNotificationTemplate(NotificationTemplateDto notificationTemplate);

        GenericServiceResponse<bool> UpdateNotificationTemplate(NotificationTemplateDto notificationTemplate);

        GenericServiceResponse<bool> DeleteNotificationTemplate(NotificationTemplateDto notificationTemplate);

        GenericServiceResponse<bool> DeleteNotificationTemplate(Guid Id);
    }
}