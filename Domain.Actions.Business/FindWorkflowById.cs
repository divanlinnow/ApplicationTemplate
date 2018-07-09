using ApplicationFramework.Notifications;
using Domain.Actions.Business.ActionTypes;
using Domain.Models.Business;
using Domain.Services.Business.ServiceProvider;
using Domain.ViewModels;
using System;

namespace Domain.Actions.Business
{
    public sealed class FindWorkflowById<T> : BasicAction<T> where T : class
    {
        public FindWorkflowById(IServiceProviderBusiness serviceProvider) : base(serviceProvider)
        {
        }

        public Func<GenericItemViewModel<WorkflowDto>, T> OnComplete { get; set; }

        public T Invoke(int id)
        {
            return Execute(() =>
            {
                var model = new GenericItemViewModel<WorkflowDto>();

                var serviceResult = ServiceProvider.WorkflowService.FindWorkflowById(id);

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
