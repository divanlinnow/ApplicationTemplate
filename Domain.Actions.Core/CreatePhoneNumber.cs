﻿using ApplicationFramework.Notifications;
using Domain.Actions.Core.ActionTypes;
using Domain.Models.Core;
using Domain.Services.Core.ServiceProvider;
using Domain.ViewModels;
using System;

namespace Domain.Actions.Core
{
    public sealed class CreatePhoneNumber<T> : BasicAction<T> where T : class
    {
        public CreatePhoneNumber(IServiceProviderCore serviceProvider) : base(serviceProvider)
        {
        }

        public Func<GenericViewModel, T> OnComplete { get; set; }

        public T Invoke(PhoneNumberDto phoneNumber)
        {
            return Execute(() =>
            {
                var model = new GenericViewModel();

                var serviceResult = ServiceProvider.PhoneNumberService.CreatePhoneNumber(phoneNumber);

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
