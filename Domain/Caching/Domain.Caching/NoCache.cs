using System;

namespace Domain.Caching
{
    public class NoCache : ICache
    {
        public bool Exists(string key)
        {
            return false;
        }

        public string GenerateKey(string cacheReference, params object[] list)
        {
            return string.Empty;
        }

        public T Get<T>(string key)
        {
            return default(T);
        }

        public void Remove(string key)
        {
            // Do nothing
        }

        public void Set<T>(string key, T value, TimeSpan expiredIn)
        {
            //Do nothing
        }
    }
}