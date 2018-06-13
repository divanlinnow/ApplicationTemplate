using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using ORM.EF.Repositories;
using System;

namespace Domain.Services.Core
{
    public abstract class ServiceBase
    {
        protected IRepository Repository { get; private set; }
        protected readonly ILogger Logger;
        protected readonly ICache Cache;
        protected readonly ITelemetry Telemetry;

        protected ServiceBase(IRepository repository, ILogger logger, ICache cache, ITelemetry telemetry)
        {
            Repository = repository;
            Logger = logger;
            Cache = cache;
            Telemetry = telemetry;
        }

        protected T TryExecute<T>(Action<T> action, object request = null) where T : IGenericServiceResponse, new()
        {
            var response = new T();

            try
            {
                action(response);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                response.Notifications.AddError("Sorry, an unexpected error occurred.");
            }

            return response;
        }
    }
}