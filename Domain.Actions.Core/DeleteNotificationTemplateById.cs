using ApplicationFramework.Notifications;
using Domain.Actions.Core.ActionTypes;
using Domain.Actions.Core.Services;
using Domain.Actions.Core.ViewModels;
using System;

namespace Domain.Actions.Core
{
    public sealed class DeleteNotificationTemplateById<T> : BasicAction<T> where T : class
    {
        public DeleteNotificationTemplateById(IClientServicesProvider clientServices) : base(clientServices)
        {
        }

        public Func<GenericViewModel, T> OnComplete { get; set; }

        public T Invoke(Guid id)
        {
            return Execute(() =>
            {
                var model = new GenericViewModel();

                var serviceResult = ClientServices.NotificationTemplateService.DeleteNotificationTemplate(id);

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
