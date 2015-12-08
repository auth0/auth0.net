using Auth0.AuthenticationApi.Client.Models;
using JetBrains.Annotations;

namespace Auth0.AuthenticationApi.Client.Builders
{
    public class AuthorizationUrlBuilder : UrlBuilderBase<AuthorizationUrlBuilder>
    {
        public AuthorizationUrlBuilder(string baseUrl) 
            : base(baseUrl, "authorize")
        {
        }

        public AuthorizationUrlBuilder WithClient(string clientId)
        {
            AddQueryString("client_id", clientId);

            return this;
        }

        public AuthorizationUrlBuilder WithConnection(string connectionName)
        {
            AddQueryString("connection", connectionName);

            return this;
        }

        public AuthorizationUrlBuilder WithDevice(string device)
        {
            AddQueryString("device", device);

            return this;
        }

        public AuthorizationUrlBuilder WithRedirectUrl(string url)
        {
            AddQueryString("redirect_uri", url);

            return this;
        }

        public AuthorizationUrlBuilder WithResponseType(AuthorizationResponseType responseType)
        {
            AddQueryString("response_type", responseType.ToString().ToLower());

            return this;
        }

        public AuthorizationUrlBuilder WithScope(string scope)
        {
            AddQueryString("scope", scope);

            return this;
        }

        public AuthorizationUrlBuilder WithState(string state)
        {
            AddQueryString("state", state);

            return this;
        }
    }
}