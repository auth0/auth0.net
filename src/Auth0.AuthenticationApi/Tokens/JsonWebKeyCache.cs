using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.Tokens
{
    internal class JsonWebKeyCache
    {
        readonly AsyncAgedCache<string, JsonWebKeySet> cache;

        public JsonWebKeyCache(JsonWebKeys jsonWebKeys)
        {
            cache = new AsyncAgedCache<string, JsonWebKeySet>(jsonWebKeys.GetForIssuer);
        }

        public Task<JsonWebKeySet> Get(string issuer, TimeSpan maxAge)
        {
            return cache.GetOrAddAsync(issuer, maxAge);
        }
    }
}