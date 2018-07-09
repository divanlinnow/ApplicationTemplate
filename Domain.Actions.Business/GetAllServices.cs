using ApplicationFramework.Notifications;
using Domain.Actions.Business.ActionTypes;
using Domain.Models.Business;
using Domain.Services.Business.ServiceProvider;
using Domain.ViewModels;
using System;

namespace Domain.Actions.Core
{
    public sealed class GetAllServices<T> : BasicAction<T> where T : class
    {
        public GetAllServices(IServiceProviderBusiness serviceProvider) : base(serviceProvider)
        {
        }

        public Func<GenericListViewModel<ServiceDto>, T> OnComplete { get; set; }

        public T Invoke()
        {
            return Execute(() =>
            {
                var model = new GenericListViewModel<ServiceDto>();

                var serviceResult = ServiceProvider.ServiceService.GetAllServices();

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
