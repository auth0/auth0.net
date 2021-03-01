using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using System;
using System.Threading.Tasks;

namespace Auth0.ManagementApi
{
    public class TokenProvider
    {
        private readonly string domain;
        private readonly string clientId;
        private readonly string clientSecret;

        private ICache cache;

        public TokenProvider(string domain, string clientId, string clientSecret, ICache cache)
        {
            this.domain = domain;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.cache = cache;
        }
        public async Task<string> GetToken()
        {
            var cacheKey = CreateCacheKey();
            var tokenStorageItem = await cache.GetAsync<TokenStorageItem>(cacheKey);

            if (tokenStorageItem == null || !isValid(tokenStorageItem))
            {
                if (tokenStorageItem != null)
                {
                    await cache.RemoveAsync(cacheKey);
                }

                using (var authClient = new AuthenticationApiClient(domain))
                {

                    var token = await authClient.GetTokenAsync(new ClientCredentialsTokenRequest
                    {
                        Audience = $"https://{domain}/api/v2/",
                        ClientId = clientId,
                        ClientSecret = clientSecret
                    });


                    await cache.SetAsync(cacheKey, new TokenStorageItem
                    {
                        AccessTokenResponse = token,
                        ExpiresAt = DateTime.Now.AddSeconds(token.ExpiresIn)
                    });

                    return token.AccessToken;
                }
            }
            

            return tokenStorageItem.AccessTokenResponse.AccessToken;
        }

        private bool isValid(TokenStorageItem token)
        {
            var leewayInSeconds = 60;

            var diff = (DateTime.Now - token.ExpiresAt);

            return diff.TotalSeconds < leewayInSeconds;
        }

        private string CreateCacheKey()
        {
            return $"{domain}-{clientId}";
        }
    }
}