﻿using ApplicationFramework.Notifications;
using Domain.Actions.Core.ActionTypes;
using Domain.Models.Core;
using Domain.Services.Core.ServiceProvider;
using Domain.ViewModels;
using System;

namespace Domain.Actions.Core
{
    public sealed class GetAllNotificationTemplates<T> : BasicAction<T> where T : class
    {
        public GetAllNotificationTemplates(IServiceProviderCore serviceProvider) : base(serviceProvider)
        {
        }

        public Func<GenericListViewModel<NotificationTemplateDto>, T> OnComplete { get; set; }

        public T Invoke()
        {
            return Execute(() =>
            {
                var model = new GenericListViewModel<NotificationTemplateDto>();

                var serviceResult = ServiceProvider.NotificationTemplateService.GetAllNotificationTemplates();

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
