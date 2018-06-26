using Domain.ServiceProvider.Core;
using Domain.Services.Business;

namespace Domain.ServiceProvider.Business
{
    public interface IServiceProviderBusiness : IBaseServiceProvider
    {
        ICurrencyService CurrencyService { get; }
    }
}
