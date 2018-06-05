using log4net;
using System.Configuration;

namespace ApplicationFramework.Logging
{
    public class Logger : ILogger
    {
        public readonly ILog Log = LogManager.GetLogger(Config.ClientLog);
        
        public void Info(object message)
        {
            Log.Info(message);
        }

        public void Warning(object message)
        {
            Log.Warn(message);
        }

        public void Error(object message)
        {
            Log.Error(message);
        }
    }
}
