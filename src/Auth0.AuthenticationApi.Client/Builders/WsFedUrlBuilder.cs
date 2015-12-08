using JetBrains.Annotations;

namespace Auth0.AuthenticationApi.Client.Builders
{
    public class WsFedUrlBuilder : UrlBuilderBase<WsFedUrlBuilder>
    {
        public WsFedUrlBuilder(string baseUrl) 
            : base(baseUrl, "wsfed/{client}")
        {
            AddUrlSegment("client", null); // Default to not using the client
        }

        public WsFedUrlBuilder WithClient(string clientId)
        {
            AddUrlSegment("client", clientId);

            return this;
        }

        public WsFedUrlBuilder WithWhr(string connectionName)
        {
            AddQueryString("whr", $"urn:{connectionName}");

            return this;
        }

        public WsFedUrlBuilder WithWtrealm(string clientId)
        {
            AddQueryString("wtrealm", $"urn:{clientId}");

            return this;
        }
    }
}