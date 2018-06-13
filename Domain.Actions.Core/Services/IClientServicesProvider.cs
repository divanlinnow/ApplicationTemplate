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

        ICountryService CountryService { get; }

        ICityService CityService { get; }
    }
}
