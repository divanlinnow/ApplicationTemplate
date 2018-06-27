namespace Domain.Services.Core.ServiceProvider
{
    public interface IServiceProviderCore : IBaseServiceProvider
    {
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
