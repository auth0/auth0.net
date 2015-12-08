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
    }
}