using ApplicationFramework.Notifications;
using Domain.Actions.Core.ActionTypes;
using Domain.ViewModels;
using Domain.ServiceProvider.Core;
using System;

namespace Domain.Actions.Core
{
    public sealed class DeleteAddressById<T> : BasicAction<T> where T : class
    {
        public DeleteAddressById(IServiceProviderCore clientServices) : base(clientServices)
        {
        }

        public Func<GenericViewModel, T> OnComplete { get; set; }

        public T Invoke(Guid id)
        {
            return Execute(() =>
            {
                var model = new GenericViewModel();

                var serviceResult = ClientServices.AddressService.DeleteAddress(id);

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
