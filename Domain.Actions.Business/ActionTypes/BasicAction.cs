using Domain.ServiceProvider.Business;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Web;

namespace Domain.Actions.Business.ActionTypes
{
    public class BasicAction<T> where T : class
    {
        protected readonly IServiceProviderBusiness ClientServices;

        public BasicAction(IServiceProviderBusiness clientServices)
        {
            this.ClientServices = clientServices;
        }

        public T Execute(Func<T> action, string callingClass, [CallerMemberName] string callerName = "")
        {
            var stopwatch = new Stopwatch();

            var callReference = Guid.NewGuid();

            ClientServices.Logger.Info($"[{callingClass}],[{callerName}] Started...");
            
            stopwatch.Start();

            try
            {
                return action();
            }
            catch (Exception ex)
            {
                ClientServices.Logger.Error(ex.Message);
                ClientServices.Logger.Error($"An error occurred while executing [{this.GetType().FullName}],[{callerName}]  Call Reference [{callReference}]");
                throw new HttpException(500, callReference.ToString());
            }
            finally
            {
                stopwatch.Stop();
                ClientServices.Logger.Info($"[{callingClass}],[{callerName}] Completed in [{stopwatch.ElapsedMilliseconds} ms]. ");
            }
        }
    }
}
