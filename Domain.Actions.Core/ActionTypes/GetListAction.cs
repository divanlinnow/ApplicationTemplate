using ApplicationFramework.Notifications;
using Domain.ServiceProvider.Core;
using Domain.Services.Core;
using Domain.ViewModels;
using System;
using System.Collections.Generic;

namespace Domain.Actions.Core.ActionTypes
{
    public abstract class GetListAction<T, K> : BasicAction<T>
        where T : class
        where K : class
    {
        protected GetListAction(IServiceProviderCore clientServices)
            : base(clientServices)
        {
            ViewModel = new GenericListViewModel<K>();
        }

        public Func<GenericListViewModel<K>, T> OnComplete { get; set; }

        protected GenericListViewModel<K> ViewModel { get; private set; }

        protected abstract GenericServiceResponse<IEnumerable<K>> InvokeInternal();

        public T Invoke()
        {
            return Execute(() =>
            {
                var result = InvokeInternal();

                if (result == null)
                {
                    ViewModel.Notifications.AddError(result.Notifications.ToString());
                    ViewModel.Items = result.Result;
                }

                return OnComplete(ViewModel);
            }, this.GetType().FullName);
        }
    }
}
