using ApplicationFramework.Notifications;
using Domain.Actions.Core.ActionTypes;
using Domain.ViewModels;
using Domain.Models.Core;
using System;
using Domain.Services.Core.ServiceProvider;

namespace Domain.Actions.Core
{
    public sealed class FindUserById<T> : BasicAction<T> where T : class
    {
        public FindUserById(IServiceProviderCore serviceProvider) : base(serviceProvider)
        {
        }

        public Func<GenericItemViewModel<UserDto>, T> OnComplete { get; set; }

        public T Invoke(Guid id)
        {
            return Execute(() =>
            {
                var model = new GenericItemViewModel<UserDto>();

                var serviceResult = ServiceProvider.UserService.FindUserById(id);

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
