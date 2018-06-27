using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Telemetry;
using System;

namespace Domain.Services.Core.ServiceProvider
{
    public interface IBaseServiceProvider : IDisposable
    {
        ILogger Logger { get; }

        ICache Cache { get; }

        ITelemetry Telemetry { get; }
    }
}
