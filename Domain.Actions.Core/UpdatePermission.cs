﻿using ApplicationFramework.Notifications;
using Domain.Actions.Core.ActionTypes;
using Domain.ViewModels;
using Domain.Models.Core;
using System;
using Domain.Services.Core.ServiceProvider;

namespace Domain.Actions.Core
{
    public sealed class UpdatePermission<T> : BasicAction<T> where T : class
    {
        public UpdatePermission(IServiceProviderCore serviceProvider) : base(serviceProvider)
        {
        }

        public Func<GenericViewModel, T> OnComplete { get; set; }

        public T Invoke(PermissionDto permission)
        {
            return Execute(() =>
            {
                var model = new GenericViewModel();

                var serviceResult = ServiceProvider.PermissionService.UpdatePermission(permission);

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
