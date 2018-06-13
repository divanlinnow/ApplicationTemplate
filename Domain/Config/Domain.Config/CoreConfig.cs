using System.Configuration;

namespace Domain.Config
{
    public static class CoreConfig
    {
        public static string SystemName
        {
            get { return ConfigurationManager.AppSettings["SystemName"]; }
        }

        public static string SystemEmailAddress
        {
            get { return ConfigurationManager.AppSettings["SystemEmailAddress"]; }
        }
    }
}