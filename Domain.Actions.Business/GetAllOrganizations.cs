using ApplicationFramework.Notifications;
using Domain.Actions.Business.ActionTypes;
using Domain.Models.Business;
using Domain.Services.Business.ServiceProvider;
using Domain.ViewModels;
using System;

namespace Domain.Actions.Core
{
    public sealed class GetAllOrganizations<T> : BasicAction<T> where T : class
    {
        public GetAllOrganizations(IServiceProviderBusiness serviceProvider) : base(serviceProvider)
        {
        }

        public Func<GenericListViewModel<OrganizationDto>, T> OnComplete { get; set; }

        public T Invoke()
        {
            return Execute(() =>
            {
                var model = new GenericListViewModel<OrganizationDto>();

                var serviceResult = ServiceProvider.OrganizationService.GetAllOrganizations();

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
