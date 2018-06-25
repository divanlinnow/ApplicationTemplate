using ApplicationFramework.Notifications;
using Domain.Actions.Core.Services;
using Domain.Actions.Core.ViewModels;
using Domain.Models.Core;
using System;

namespace Domain.Actions.Core
{
    public sealed class CreateNotificationTemplate<T> : BasicAction<T> where T : class
    {
        public CreateNotificationTemplate(IClientServicesProvider clientServices) : base(clientServices)
        {
        }

        public Func<GenericViewModel, T> OnComplete { get; set; }

        public T Invoke(NotificationTemplateDto notificationTemplate)
        {
            return Execute(() =>
            {
                var model = new GenericViewModel();

                var serviceResult = ClientServices.NotificationTemplateService.CreateNotificationTemplate(notificationTemplate);

                if (serviceResult == null || serviceResult.Notifications.HasErrors())
                {
                    var errorMessage = "Sorry, an unexpected error occurred.";
                    model.Notifications.AddError(errorMessage);
                }
                else
                {
                    model.Success = serviceResult.Result;
                }

                return OnComplete(model);

            }, this.GetType().Name);
        }
    }
}
