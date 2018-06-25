using ApplicationFramework.Notifications;
using Domain.Actions.Core.Services;
using Domain.Actions.Core.ViewModels;
using Domain.Models.Core;
using System;

namespace Domain.Actions.Core
{
    public sealed class FindNotificationTemplateById<T> : BasicAction<T> where T : class
    {
        public FindNotificationTemplateById(IClientServicesProvider clientServices) : base(clientServices)
        {
        }

        public Func<GenericItemViewModel<NotificationTemplateDto>, T> OnComplete { get; set; }

        public T Invoke(Guid id)
        {
            return Execute(() =>
            {
                var model = new GenericItemViewModel<NotificationTemplateDto>();

                var serviceResult = ClientServices.NotificationTemplateService.FindNotificationTemplateById(id);

                if (serviceResult == null || serviceResult.Result == null || serviceResult.Notifications.HasErrors())
                {
                    var errorMessage = "Sorry, an unexpected error occurred.";
                    model.Notifications.AddError(errorMessage);
                }
                else
                {
                    model.Item = serviceResult.Result;
                }

                return OnComplete(model);

            }, this.GetType().Name);
        }
    }
}
