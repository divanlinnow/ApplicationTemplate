using ApplicationFramework.Notifications;
using Domain.Actions.Core.ActionTypes;
using Domain.ViewModels;
using Domain.Models.Core;
using System;
using Domain.Services.Core.ServiceProvider;

namespace Domain.Actions.Core
{
    public sealed class UpdateUser<T> : BasicAction<T> where T : class
    {
        public UpdateUser(IServiceProviderCore serviceProvider) : base(serviceProvider)
        {
        }

        public Func<GenericViewModel, T> OnComplete { get; set; }

        public T Invoke(UserDto user)
        {
            return Execute(() =>
            {
                var model = new GenericViewModel();

                var serviceResult = ServiceProvider.UserService.UpdateUser(user);

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
