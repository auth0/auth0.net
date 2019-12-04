using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.Tokens
{
    internal class KeyedCache<T>
    {
        struct Entry
        {
            public T Value;
            public DateTime CachedAt;
            public DateTime LastAccess;
            public DateTime ExpireAt;
        }

        readonly ConcurrentDictionary<string, Entry> cache = new ConcurrentDictionary<string, Entry>();

        public DateTime? GetCachedAt(string key)
        {
            if (cache.TryGetValue(key, out Entry entry))
                return entry.CachedAt;

            return null;
        }

        public void Add(string key, TimeSpan maxAge, T newValue)
        {
            var now = DateTime.UtcNow;
            cache.TryAdd(key, new Entry { CachedAt = now, LastAccess = now, Value = newValue, ExpireAt = now.Add(maxAge) });
            PruneExpiredEntries();
        }

        public async Task<T> AddAsync(string key, TimeSpan maxAge, Func<Task<T>> valueFactory) {
            var newValue = await valueFactory();
            Add(key, maxAge, newValue);
            return newValue;
        }

        public Task<T> GetOrAddAsync(string key, TimeSpan maxAge, Func<Task<T>> valueFactory)
        {
            var now = DateTime.UtcNow;
            if (cache.TryGetValue(key, out Entry entry))
            {
                var cutOff = now.Subtract(maxAge);
                if (entry.CachedAt > cutOff)
                {
                    entry.LastAccess = now;
                    return Task.FromResult(entry.Value);
                }
                else
                {
                    cache.TryRemove(key, out Entry _);
                }
            }

            return AddAsync(key, maxAge, valueFactory);
        }

        private void PruneExpiredEntries()
        {
            var now = DateTime.UtcNow;
            foreach (var item in cache)
                if (item.Value.ExpireAt < now)
                    cache.TryRemove(item.Key, out _);
        }
    }
}
