using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.Tokens
{
    internal class KeyedCache<T>
    {
        struct Entry
        {
            public Task<T> Task;
            public DateTime CachedAt;
        }

        readonly ConcurrentDictionary<string, Entry> cache = new ConcurrentDictionary<string, Entry>();

        public Task<T> GetOrAddAsync(string key, TimeSpan maxAge, Func<Task<T>> valueFactory)
        {
            var now = DateTime.UtcNow;
            if (cache.TryGetValue(key, out Entry entry) && (entry.CachedAt.Add(maxAge) < now))
                return entry.Task;

            var task = valueFactory();
            cache.TryAdd(key, new Entry { Task = task, CachedAt = now });
            return task;
        }
    }
}
