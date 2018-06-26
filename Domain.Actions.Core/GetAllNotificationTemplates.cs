using ApplicationFramework.Notifications;
using Domain.Actions.Core.ActionTypes;
using Domain.ViewModels;
using Domain.Models.Core;
using Domain.ServiceProvider.Core;
using System;

namespace Domain.Actions.Core
{
    public sealed class GetAllNotificationTemplates<T> : BasicAction<T> where T : class
    {
        public GetAllNotificationTemplates(IServiceProviderCore clientServices) : base(clientServices)
        {
        }

        public Func<GenericListViewModel<NotificationTemplateDto>, T> OnComplete { get; set; }

        public T Invoke()
        {
            return Execute(() =>
            {
                var model = new GenericListViewModel<NotificationTemplateDto>();

                var serviceResult = ClientServices.NotificationTemplateService.GetAllNotificationTemplates();

                if (serviceResult == null || serviceResult.Result == null || serviceResult.Notifications.HasErrors())
                {
                    var errorMessage = "Sorry, an unexpected error occurred.";
                    model.Notifications.AddError(errorMessage);
                }
                else
                {
                    model.Items = serviceResult.Result;
                }

                return OnComplete(model);

            }, this.GetType().Name);
        }
    }
}
