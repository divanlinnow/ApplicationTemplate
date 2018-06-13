using ApplicationFramework.Notifications;
using Domain.Actions.Core.Services;
using Domain.Actions.Core.ViewModels;
using Domain.Models.Core;
using System;

namespace Domain.Actions.Core
{
    public sealed class GetAllCountries<T> : BasicAction<T> where T : class
    {
        public GetAllCountries(IClientServicesProvider clientServices) : base(clientServices)
        {
        }

        public Func<GenericListViewModel<CountryDto>, T> OnComplete { get; set; }

        public T Invoke()
        {
            return Execute(() =>
            {
                var model = new GenericListViewModel<CountryDto>();

                var serviceResult = ClientServices.CountryService.GetAllCountries();

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
