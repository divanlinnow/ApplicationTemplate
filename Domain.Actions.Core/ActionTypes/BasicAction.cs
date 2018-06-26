using Domain.ServiceProvider.Core;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Web;

namespace Domain.Actions.Core.ActionTypes
{
    public class BasicAction<T> where T : class
    {
        protected readonly IServiceProviderCore ServiceProvider;

        public BasicAction(IServiceProviderCore serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        public T Execute(Func<T> action, string callingClass, [CallerMemberName] string callerName = "")
        {
            var stopwatch = new Stopwatch();

            var callReference = Guid.NewGuid();

            ServiceProvider.Logger.Info($"[{callingClass}],[{callerName}] Started...");
            
            stopwatch.Start();

            try
            {
                return action();
            }
            catch (Exception ex)
            {
                ServiceProvider.Logger.Error(ex.Message);
                ServiceProvider.Logger.Error($"An error occurred while executing [{this.GetType().FullName}],[{callerName}]  Call Reference [{callReference}]");
                throw new HttpException(500, callReference.ToString());
            }
            finally
            {
                stopwatch.Stop();
                ServiceProvider.Logger.Info($"[{callingClass}],[{callerName}] Completed in [{stopwatch.ElapsedMilliseconds} ms]. ");
            }
        }
    }
}
