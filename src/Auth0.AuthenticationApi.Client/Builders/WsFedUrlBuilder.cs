using System.Collections.Generic;
using JetBrains.Annotations;
using System.Linq;

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

        public WsFedUrlBuilder WithWhr(string value)
        {
            AddQueryString("whr", value);

            return this;
        }

        public WsFedUrlBuilder WithWctx(string value)
        {
            AddQueryString("wctx", value);

            return this;
        }

        public WsFedUrlBuilder WithWctx(IDictionary<string, string> values)
        {
            AddQueryString("wctx", string.Join("&", values.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value))));

            return this;
        }

        public WsFedUrlBuilder WithWtrealm(string value)
        {
            AddQueryString("wtrealm", value);

            return this;
        }
    }
}