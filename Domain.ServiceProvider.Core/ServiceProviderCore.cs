using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Telemetry;
using Domain.Services.Core;
using System;
using Unity;
using Unity.Attributes;

namespace Domain.ServiceProvider.Core
{
    public class ServiceProviderCore : IServiceProviderCore
    {
        private bool disposed;

        [Dependency]
        protected IUnityContainer Container { get; set; }

        [Dependency]
        public ILogger Logger { get; set; }

        [Dependency]
        public ICache Cache { get; set; }

        [Dependency]
        public ITelemetry Telemetry { get; set; }

        [Dependency]
        public IAddressService AddressService { get; set; }

        [Dependency]
        public ICityService CityService { get; set; }

        [Dependency]
        public ICountryService CountryService { get; set; }

        [Dependency]
        public IEmailService EmailService { get; set; }

        [Dependency]
        public ILanguageService LanguageService { get; set; }

        [Dependency]
        public INotificationTemplateService NotificationTemplateService { get; set; }

        [Dependency]
        public IPermissionService PermissionService { get; set; }

        [Dependency]
        public IPhoneNumberService PhoneNumberService { get; set; }

        [Dependency]
        public IProvinceService ProvinceService { get; set; }

        [Dependency]
        public IRoleService RoleService { get; set; }

        [Dependency]
        public IUserService UserService { get; set; }

        #region IDisposable implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ServiceProviderCore()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }


            if (disposing)
            {
                if (Container != null)
                {
                    Container.Dispose();
                    Container = null;
                }
            }

            // release any unmanaged objects
            // set the object references to null

            disposed = true;
        }

        #endregion
    }
}
