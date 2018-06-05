using System;

namespace Domain.Caching
{
    public interface ICache
    {
        bool Exists(string key);

        T Get<T>(string key);

        void Set<T>(string key, T value, TimeSpan expiredIn);

        void Remove(string key);

        string GenerateKey(string cacheReference, params object[] list);
    }
}