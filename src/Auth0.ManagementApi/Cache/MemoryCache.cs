using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Auth0.ManagementApi
{
    public class MemoryCache : ICache
    {
        private Dictionary<string, Object> storage = new Dictionary<string, Object>();

        public Task<T> GetAsync<T>(string key, CancellationToken token = default) where T : class
        {
            return Task.FromResult(storage.ContainsKey(key) ? storage[key] as T : null);
        }

        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            storage.Remove(key);
            return Task.FromResult(0);
        }

        public Task SetAsync<T>(string key, T value, CancellationToken token = default)
        {
            if (storage.ContainsKey(key))
            {
                storage[key] = value;
            }
            else
            {
                storage.Add(key, value);
            }

            return Task.FromResult(0);
        }
    }
}