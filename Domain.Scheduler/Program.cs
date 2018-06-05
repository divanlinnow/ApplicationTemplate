using System;
using System.ServiceModel;
using Topshelf;
using Topshelf.Logging;

namespace Domain.Scheduler
{
    public class Program
    {
        public static ServiceHost serviceHost = null;

        private static int Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            // Topshelf to use Log4Net
            Log4NetLogWriterFactory.Use();

            StartStatusService();

            int result = ConfigureAndRunServiceHost();
            return result;
        }

        private static int ConfigureAndRunServiceHost()
        {
            return (int)HostFactory.Run(x =>
            {
                x.Service<SchedulerService>();

                x.RunAsNetworkService();
                x.DependsOnEventLog();
                x.StartAutomaticallyDelayed();

                x.SetServiceName("Tescodesign.com.Scheduler");
                x.SetDisplayName("Tescodesign.com Job Scheduler");
                x.SetDescription("Manages recurring jobs that need to be run on a timed interval.");
            });
        }

        private static void StartStatusService()
        {
            if (serviceHost.IsNotNull())
            {
                serviceHost.Close();
            }

            try
            {
                serviceHost = new ServiceHost(typeof(StatusService));

                serviceHost.Open();

            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger("tesco.logger").Error(ex.ToString());
            }
        }
    }
}
