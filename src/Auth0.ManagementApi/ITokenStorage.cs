using Auth0.AuthenticationApi.Models;

namespace Auth0.ManagementApi
{
    public interface ITokenStorage
    {
        void Save(string clientId, string domain, AccessTokenResponse token);
        TokenStorageItem Get(string clientId, string domain);
        void Remove(string clientId, string domain);
    }
}