﻿using ApplicationFramework.Notifications;
using Domain.Actions.Business.ActionTypes;
using Domain.Models.Business;
using Domain.Services.Business.ServiceProvider;
using Domain.ViewModels;
using System;

namespace Domain.Actions.Core
{
    public sealed class DeleteAddress<T> : BasicAction<T> where T : class
    {
        public DeleteAddress(IServiceProviderBusiness serviceProvider) : base(serviceProvider)
        {
        }

        public Func<GenericViewModel, T> OnComplete { get; set; }

        public T Invoke(CurrencyDto currency)
        {
            return Execute(() =>
            {
                var model = new GenericViewModel();

                var serviceResult = ServiceProvider.CurrencyService.DeleteCurrency(currency);

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