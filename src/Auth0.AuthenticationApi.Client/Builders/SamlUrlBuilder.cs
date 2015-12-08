using System.Linq;

namespace Auth0.AuthenticationApi.Client.Builders
{
    public class SamlUrlBuilder : UrlBuilderBase<SamlUrlBuilder>
    {
        private string ConnectionName { get; set; }

        public SamlUrlBuilder(string baseUrl, string client)
            :base(baseUrl, "samlp/{client}")
        {
            AddUrlSegment("client", client);
        }

        public SamlUrlBuilder WithConnection(string connectionName)
        {
            AddQueryString("connection", connectionName);

            return this;
        }

        public SamlUrlBuilder WithRelayState(string value)
        {
            AddQueryString("relayState", value);

            return this;
        }

        public SamlUrlBuilder WithRelayState(System.Collections.Generic.IDictionary<string, string> values)
        {
            AddQueryString("relayState", string.Join("&", values.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value))));

            return this;
        }

    }
}