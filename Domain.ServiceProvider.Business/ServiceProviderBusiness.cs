using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Telemetry;
using Domain.Services.Business;
using System;
using Unity;
using Unity.Attributes;

namespace Domain.ServiceProvider.Business
{
    public class ServiceProviderBusiness : IServiceProviderBusiness
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
        public ICurrencyService CurrencyService { get; set; }
        



        #region IDisposable implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ServiceProviderBusiness()
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
