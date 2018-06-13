using System;
using System.Configuration;

namespace ApplicationFramework.Caching
{
    public class RedisServerSettings : ConfigurationSection, IRedisServerSettings
    {
        [ConfigurationProperty("PreferSlaveForRead", IsRequired = false, DefaultValue = false)]
        public bool PreferSlaveForRead
        {
            get
            {
                return Convert.ToBoolean(this["PreferSlaveForRead"]);
            }
        }

        [ConfigurationProperty("ConnectionStringOrName", IsRequired = true)]
        public string ConnectionStringOrName
        {
            get
            {
                return this["ConnectionStringOrName"] as string;
            }
        }

        [ConfigurationProperty("DefaultDb", IsRequired = false, DefaultValue = 0)]
        public int DefaultDb
        {
            get
            {
                return Convert.ToInt32(this["DefaultDb"]);
            }
        }
    }
}
