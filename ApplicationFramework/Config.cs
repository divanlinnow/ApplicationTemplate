using System.Configuration;

namespace ApplicationFramework
{
    public static class Config
    {
        public static string ClientLog => ConfigurationManager.AppSettings["ClientLog"];

        public static string StorageConnectionString => Microsoft.Azure.CloudConfigurationManager.GetSetting("StorageConnection");

        /// <summary>
        /// If this is true and the container has not been created it will create the container with public access
        /// </summary>
        public static bool HasPublicAccess
        {
            get
            {
                bool hasPublicAccess = false;

                var hasPublicAccessSetting = Microsoft.Azure.CloudConfigurationManager.GetSetting("HasPublicAccess");

                if (hasPublicAccessSetting != null)
                {
                    bool.TryParse(hasPublicAccessSetting, out hasPublicAccess);
                }

                return hasPublicAccess;
            }
        }

        public static string ApplicationInsightsInstrumentionKey => Microsoft.Azure.CloudConfigurationManager.GetSetting("ApplicationInsightsInstrumentionKey");
    }
}
