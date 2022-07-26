using Microsoft.IdentityModel.Tokens;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.Tokens
{
    internal class JsonWebKeyCache
    {
        private JsonWebKeys keys;
        public JsonWebKeyCache(HttpClient httpClient)
        {
            keys = new JsonWebKeys(httpClient); 
            cache = new AsyncAgedCache<string, JsonWebKeySet>(keys.GetForIssuer);
        }

        readonly AsyncAgedCache<string, JsonWebKeySet> cache;

        public Task<JsonWebKeySet> Get(string issuer, TimeSpan maxAge)
        {
            return cache.GetOrAddAsync(issuer, maxAge);
        }
    }
}