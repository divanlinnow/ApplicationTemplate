using ApplicationFramework.Notifications;
using Domain.Actions.Core.Services;
using Domain.Actions.Core.ViewModels;
using Domain.Models.Core;
using System;

namespace Domain.Actions.Core
{
    public sealed class FindCityById<T> : BasicAction<T> where T : class
    {
        public FindCityById(IClientServicesProvider clientServices) : base(clientServices)
        {
        }

        public Func<GenericItemViewModel<CityDto>, T> OnComplete { get; set; }

        public T Invoke(Guid id)
        {
            return Execute(() =>
            {
                var model = new GenericItemViewModel<CityDto>();

                var serviceResult = ClientServices.CityService.FindCityById(id);

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
