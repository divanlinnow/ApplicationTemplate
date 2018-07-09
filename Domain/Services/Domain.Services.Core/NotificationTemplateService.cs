using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Core;
using Domain.Mappings.Core;
using Domain.Models.Core;
using ORM.EF.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Core
{
    public class NotificationTemplateService : ServiceBase, INotificationTemplateService
    {
        #region Constructor

        public NotificationTemplateService(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry) : base(repository, logger, cache, telemetry)
        {
        }

        #endregion Constructor

        #region Methods

        public GenericServiceResponse<IEnumerable<NotificationTemplateDto>> GetAllNotificationTemplates()
        {
            return TryExecute<GenericServiceResponse<IEnumerable<NotificationTemplateDto>>>((response) =>
            {
                response.Result = Repository.All<NotificationTemplate>().ToList().AsDto();

                if ((response.Result == null) || (response.Result.Count() <= 0))
                {
                    var errorMessage = "'GetAllNotificationTemplates' was unable to find any notificationTemplate records.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<NotificationTemplateDto> FindNotificationTemplateById(int Id)
        {
            return TryExecute<GenericServiceResponse<NotificationTemplateDto>>((response) =>
            {
                response.Result = Repository.FindById<NotificationTemplate>(Id).AsDto();

                if (response.Result == null)
                {
                    var errorMessage = "'FindNotificationTemplateById' was unable to find the given notificationTemplate record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> CreateNotificationTemplate(NotificationTemplateDto notificationTemplate)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Insert(notificationTemplate.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'CreateNotificationTemplate' was unable to insert a new notificationTemplate record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> UpdateNotificationTemplate(NotificationTemplateDto notificationTemplate)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Update(notificationTemplate.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'UpdateNotificationTemplate' was unable to update the given notificationTemplate record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteNotificationTemplate(NotificationTemplateDto notificationTemplate)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete(notificationTemplate.AsEntity());

                if (!response.Result)
                {
                    var errorMessage = "'DeleteNotificationTemplate' was unable to delete the given notificationTemplate record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        public GenericServiceResponse<bool> DeleteNotificationTemplate(int Id)
        {
            return TryExecute<GenericServiceResponse<bool>>((response) =>
            {
                response.Result = Repository.Delete<NotificationTemplate>(Id);

                if (!response.Result)
                {
                    var errorMessage = "'DeleteNotificationTemplate' was unable to delete the given notificationTemplate record.";
                    response.Notifications.AddError(errorMessage);
                    Logger.Error(errorMessage);
                }
            });
        }

        #endregion Methods
    }
}