using ApplicationFramework.Notifications;
using Domain.Actions.Business.ActionTypes;
using Domain.Models.Business;
using Domain.Services.Business.ServiceProvider;
using Domain.ViewModels;
using System;

namespace Domain.Actions.Core
{
    public sealed class GetAllCurrencies<T> : BasicAction<T> where T : class
    {
        public GetAllCurrencies(IServiceProviderBusiness clientServices) : base(clientServices)
        {
        }

        public Func<GenericListViewModel<CurrencyDto>, T> OnComplete { get; set; }

        public T Invoke()
        {
            return Execute(() =>
            {
                var model = new GenericListViewModel<CurrencyDto>();

                var serviceResult = ClientServices.CurrencyService.GetAllCurrencies();

                if (serviceResult == null || serviceResult.Result == null || serviceResult.Notifications.HasErrors())
                {
                    model.Notifications.AddError("Sorry, an unexpected error occurred.");
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
