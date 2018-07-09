using ApplicationFramework.Notifications;
using Domain.Actions.Core.ActionTypes;
using Domain.Models.Core;
using Domain.Services.Core.ServiceProvider;
using Domain.ViewModels;
using System;

namespace Domain.Actions.Core
{
    public sealed class FindCountryById<T> : BasicAction<T> where T : class
    {
        public FindCountryById(IServiceProviderCore serviceProvider) : base(serviceProvider)
        {
        }

        public Func<GenericItemViewModel<CountryDto>, T> OnComplete { get; set; }

        public T Invoke(int id)
        {
            return Execute(() =>
            {
                var model = new GenericItemViewModel<CountryDto>();

                var serviceResult = ServiceProvider.CountryService.FindCountryById(id);

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
