using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.Tokens
{
    internal class AsyncAgedCache<TKey, TValue>
    {
        struct Entry
        {
            public Task<TValue> Task;
            public DateTime CachedAt;
        }

        readonly ConcurrentDictionary<TKey, Entry> cache = new ConcurrentDictionary<TKey, Entry>();
        readonly Func<TKey, Task<TValue>> valueFactory;

        public AsyncAgedCache(Func<TKey, Task<TValue>> valueFactory)
        {
            this.valueFactory = valueFactory;
        }

        public Task<TValue> GetOrAddAsync(TKey key, TimeSpan maxAge)
        {
            var now = DateTime.UtcNow;
            if (cache.TryGetValue(key, out Entry entry))
            {
                var cacheExpiresAt = entry.CachedAt.Add(maxAge);
                if (now < cacheExpiresAt)
                    return entry.Task;
                
                // When a cache entry was found, but expired, we want to remove it.
                cache.TryRemove(key, out _);
            }

            var task = valueFactory(key);
            cache.TryAdd(key, new Entry { Task = task, CachedAt = now });
            return task;
        }
    }
}
