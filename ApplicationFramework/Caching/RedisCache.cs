using ApplicationFramework.Serialization;
using StackExchange.Redis;
using System;
using System.Linq;

namespace ApplicationFramework.Caching
{
    public class RedisCache : ICache
    {
        private readonly IDatabase _database;
        private readonly ISerializer _serializer;
        private readonly CommandFlags _readFlag;

        public RedisCache(IRedisConnectionWrapper connectionWrapper, IRedisServerSettings settings, ISerializer serializer)
        {
            _database = connectionWrapper.Database(settings.DefaultDb);
            _serializer = serializer;
            _readFlag = settings.PreferSlaveForRead ? CommandFlags.PreferSlave : CommandFlags.PreferMaster;
        }

        public bool Exists(string key)
        {
            return _database.KeyExists(key, _readFlag);
        }

        public T Get<T>(string key)
        {
            return _serializer.Deserialize<T>(_database.StringGet(key, CommandFlags.PreferSlave));
        }

        public void Set<T>(string key, T value, TimeSpan expiredIn)
        {
            _database.StringSetAsync(key, _serializer.Serialize(value), expiredIn).Wait();
        }

        public void Remove(string key)
        {
            _database.KeyDelete(key);
        }

        public string GenerateKey(string cacheReference, params object[] list)
        {
            return string.Format("{0}_{1}", cacheReference, string.Join("_", list.Select(p => p ?? "_null")));
        }
    }
}
