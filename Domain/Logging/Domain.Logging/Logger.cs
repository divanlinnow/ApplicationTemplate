using log4net;

namespace Domain.Logging
{
    public class Logger : ILogger
    {
        public readonly ILog Log = LogManager.GetLogger(Config.CoreConfig.ClientLog);

        public void Error(object message)
        {
            Log.Error(message);
        }

        public void Warning(object message)
        {
            Log.Warn(message);
        }

        public void Info(object message)
        {
            Log.Info(message);
        }
    }
}