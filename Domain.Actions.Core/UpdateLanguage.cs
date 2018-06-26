using ApplicationFramework.Notifications;
using Domain.Actions.Core.ActionTypes;
using Domain.ViewModels;
using Domain.Models.Core;
using Domain.ServiceProvider.Core;
using System;

namespace Domain.Actions.Core
{
    public sealed class UpdateLanguage<T> : BasicAction<T> where T : class
    {
        public UpdateLanguage(IServiceProviderCore clientServices) : base(clientServices)
        {
        }

        public Func<GenericViewModel, T> OnComplete { get; set; }

        public T Invoke(LanguageDto language)
        {
            return Execute(() =>
            {
                var model = new GenericViewModel();

                var serviceResult = ClientServices.LanguageService.UpdateLanguage(language);

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
