﻿using ApplicationFramework.Notifications;
using Domain.Actions.Business.ActionTypes;
using Domain.Models.Business;
using Domain.Services.Business.ServiceProvider;
using Domain.ViewModels;
using System;

namespace Domain.Actions.Business
{
    public sealed class CreateProduct<T> : BasicAction<T> where T : class
    {
        public CreateProduct(IServiceProviderBusiness serviceProvider) : base(serviceProvider)
        {
        }

        public Func<GenericViewModel, T> OnComplete { get; set; }

        public T Invoke(ProductDto product)
        {
            return Execute(() =>
            {
                var model = new GenericViewModel();

                var serviceResult = ServiceProvider.ProductService.CreateProduct(product);

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