﻿using ApplicationFramework.Notifications;
using Domain.Actions.Core.ActionTypes;
using Domain.ViewModels;
using Domain.Models.Core;
using Domain.ServiceProvider.Core;
using System;

namespace Domain.Actions.Core
{
    public sealed class UpdateCity<T> : BasicAction<T> where T : class
    {
        public UpdateCity(IServiceProviderCore clientServices) : base(clientServices)
        {
        }

        public Func<GenericViewModel, T> OnComplete { get; set; }

        public T Invoke(CityDto city)
        {
            return Execute(() =>
            {
                var model = new GenericViewModel();

                var serviceResult = ClientServices.CityService.UpdateCity(city);

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
