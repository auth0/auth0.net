using Auth0.AuthenticationApi.Tokens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests.Tokens
{
    public class AsyncAgedCacheTests
    {
        [Fact]
        public async Task CallsFactoryWhenNotYetCached()
        {
            var factoryCallCount = 0;
            Task<int> factory(string s) => Task.FromResult(factoryCallCount++);
            var cache = new AsyncAgedCache<string, int>(factory);

            Assert.Equal(0, factoryCallCount);
            await cache.GetOrAddAsync("abc", TimeSpan.FromSeconds(30));
            Assert.Equal(1, factoryCallCount);
        }

        [Fact]
        public async Task DoesNotCallFactoryWhenAlreadyCached()
        {
            var factoryCallCount = 0;
            Task<int> factory(string s) => Task.FromResult(factoryCallCount++);
            var cache = new AsyncAgedCache<string, int>(factory);

            await cache.GetOrAddAsync("abc", TimeSpan.FromSeconds(30));
            Assert.Equal(1, factoryCallCount);
            await cache.GetOrAddAsync("abc", TimeSpan.FromSeconds(30));
            Assert.Equal(1, factoryCallCount);
        }
        
        [Fact]
        public async Task CorrectlyUpdatesTheCache()
        {
            var factoryCallCount = 0;
            Task<int> factory(string s) => Task.FromResult(factoryCallCount++);
            var cache = new AsyncAgedCache<string, int>(factory);

            await cache.GetOrAddAsync("abc", TimeSpan.FromSeconds(1));
            Assert.Equal(1, factoryCallCount);
            await cache.GetOrAddAsync("abc", TimeSpan.FromSeconds(1));
            Assert.Equal(1, factoryCallCount);
            
            // Wait 2 sec
            await Task.Delay(2000);
            factoryCallCount = 0;
            
            await cache.GetOrAddAsync("abc", TimeSpan.FromSeconds(1));
            Assert.Equal(1, factoryCallCount);
            await cache.GetOrAddAsync("abc", TimeSpan.FromSeconds(1));
            Assert.Equal(1, factoryCallCount);
        }

        [Fact]
        public async Task DoesNotCallFactoryWithWrongKey()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary["a"] = 0;
            dictionary["b"] = 0;

            Task<int> factoryA(string s) => Task.FromResult(dictionary[s]++);
            var cache = new AsyncAgedCache<string, int>(factoryA);

            await cache.GetOrAddAsync("a", TimeSpan.FromSeconds(30));
            Assert.Equal(1, dictionary["a"]);
            Assert.Equal(0, dictionary["b"]);
            await cache.GetOrAddAsync("b", TimeSpan.FromSeconds(30));
            Assert.Equal(1, dictionary["b"]);
        }

        [Fact]
        public async Task CallsFactoryWhenKeyIsExpired()
        {
            var factoryCallCount = 0;
            Task<int> factory(string s) => Task.FromResult(factoryCallCount++);
            var cache = new AsyncAgedCache<string, int>(factory);

            Assert.Equal(0, factoryCallCount);
            await cache.GetOrAddAsync("abc", TimeSpan.FromSeconds(30));
            Assert.Equal(1, factoryCallCount);
            await cache.GetOrAddAsync("abc", TimeSpan.FromSeconds(0));
            Assert.Equal(2, factoryCallCount);
        }
    }
}
