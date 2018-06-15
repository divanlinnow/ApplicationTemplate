using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Telemetry;
using Domain.Services.Core;
using System;

namespace Domain.Actions.Core.Services
{
    public interface IClientServicesProvider : IDisposable
    {
        ILogger Logger { get; }

        ICache Cache { get; }

        ITelemetry Telemetry { get; }

        IAddressService AddressService { get; }
        
        ICityService CityService { get; }

        ICountryService CountryService { get; }
        
        IEmailService EmailService { get; }

        ILanguageService LanguageService { get; }

        INotificationTemplateService NotificationTemplateService { get; }

        IPermissionService PermissionService { get; }

        IPhoneNumberService PhoneNumberService { get; }

        IProvinceService ProvinceService { get; }

        IRoleService RoleService { get; }

        IUserService UserService { get; }
    }
}
