using ApplicationFramework.Notifications;
using Domain.Actions.Core.ActionTypes;
using Domain.Actions.Core.Services;
using Domain.Actions.Core.ViewModels;
using Domain.Models.Business;
using System;

namespace Domain.Actions.Core
{
    public sealed class GetAllCurrencies<T> : BasicAction<T> where T : class
    {
        public GetAllCurrencies(IClientServicesProvider clientServices) : base(clientServices)
        {
        }

        public Func<GenericListViewModel<CurrencyDto>, T> OnComplete { get; set; }

        public T Invoke()
        {
            return Execute(() =>
            {
                var model = new GenericListViewModel<CurrencyDto>();

                //var serviceResult = ClientServices.CurrencyService.GetAllCurrencies();

                //if (serviceResult == null || serviceResult.Result == null || serviceResult.Notifications.HasErrors())
                //{
                //    model.Notifications.AddError("Sorry, an unexpected error occurred.");
                //}
                //else
                //{
                //    model.Items = serviceResult.Result;
                //}

                return OnComplete(model);

            }, this.GetType().Name);
        }
    }
}
