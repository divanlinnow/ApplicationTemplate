﻿using System;
using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Telemetry;
using Domain.Services.Core;
using Unity;
using Unity.Attributes;

namespace Domain.Actions.Core.Services
{
    // Need to seperate this into its own project
    public class ClientServicesProvider : IClientServicesProvider
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

        #region IDisposable implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ClientServicesProvider()
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